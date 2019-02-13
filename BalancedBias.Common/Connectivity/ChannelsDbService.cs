using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BalancedBias.Common.Config;
using BalancedBias.Common.Rss;

namespace BalancedBias.Common.Connectivity
{
    /// <summary>
    /// Service to handle reading and writing data to Channels database table
    /// </summary>
    public class ChannelsDbService : IChannelsDbService
    {
        /// <summary>
        /// Connection string for accessing Channels database table
        /// </summary>
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["channelsDb"].ConnectionString;

        /// <summary>
        /// Configuration section for RssChannelsService
        /// </summary>
        private static readonly RssChannelsServiceSection Config = (RssChannelsServiceSection)ConfigurationManager.GetSection("rssChannelsService");

        /// <summary>
        /// Writes a new article to the Channels database table
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="title"></param>
        /// <param name="url"></param>
        /// <param name="publishDate"></param>
        /// <param name="description"></param>
        public void AddNewArticle(string channel, string title, string url, string publishDate, string description)
        {
            var command = new SqlCommand
            {
                CommandText = "add_new_article",
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@Channel", channel));
            command.Parameters.Add(new SqlParameter("@Title", title));
            command.Parameters.Add(new SqlParameter("@Body", description));
            command.Parameters.Add(new SqlParameter("@Url", url));
            command.Parameters.Add(new SqlParameter("@PublishDate", publishDate));

            if (!IsArticleUnique(title)) return;
            var reader = DbHelper.ExecuteReader(ConnectionString, command);
            reader.Close();
        }

        /// <summary>
        /// Reads channels from database by inputted date
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Collection of channels</returns>
        public NewsCollection GetChannelsFromDbByDate(string date)
        {
            var newsCollection = new NewsCollection();
            if (Config == null) return newsCollection;
            foreach (ChannelElement channel in Config.Channels)
            {
                newsCollection.Channels.Add(GetArticlesByDateAndChannel(channel, date));
            }
            return newsCollection;
        }

        /// <summary>
        /// Reads all unique article dates by string
        /// </summary>
        /// <returns>List of unique article dates as strings</returns>
        public List<string> GetUniqueArticleDates()
        {
            var uniqueDates = new List<string>();
            var command = new SqlCommand
            {
                CommandText = "get_all_stored_dates",
                CommandType = CommandType.StoredProcedure
            };
            var reader = (SqlDataReader)DbHelper.ExecuteReader(ConnectionString, command);
            if (reader == null) return uniqueDates;
            while (reader.Read())
            {
                var date = Convert.ToString(reader["publishDate"]).Split(null)[0];
                if (!uniqueDates.Contains(date))
                {
                    uniqueDates.Add(date);
                }
            }
            reader.Close();
            return uniqueDates;
        }

        /// <summary>
        /// Gets all articles from database according to inputted channel and date published 
        /// </summary>
        /// <param name="channelElement"></param>
        /// <param name="publishDate"></param>
        /// <returns>Channel containing all articles from inputted date</returns>
        public Channel GetArticlesByDateAndChannel(ChannelElement channelElement, string publishDate)
        {
            var channel = new Channel
            {
                Name = channelElement.Name,
                Icon = channelElement.Icon
            };

            var command = new SqlCommand
            {
                CommandText = "get_articles_by_date_and_channel",
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@Channel", channel.Name));
            command.Parameters.Add(new SqlParameter("@Date", publishDate));
            var reader = (SqlDataReader)DbHelper.ExecuteReader(ConnectionString, command);
            if (reader == null) return channel;
            while (reader.Read())
            {
                var article = new Article
                {
                    Channel = Convert.ToString(reader["channel"].ToString()),
                    Title = Convert.ToString(reader["title"].ToString()),
                    Body = Convert.ToString(reader["body"].ToString()),
                    Url = string.IsNullOrEmpty(reader["url"].ToString())
                            ? ""
                            : reader["url"].ToString(),
                    PublishDate = Convert.ToString(reader["publishDate"].ToString())
                };
                channel.Articles.Add(article);
            }
            reader.Close();
            return channel;
        }

        /// <summary>
        /// Checks if inputted article title is already written to the database
        /// </summary>
        /// <param name="title"></param>
        /// <returns>Bool reflecting if inputted article is unique in database</returns>
        public bool IsArticleUnique(string title)
        {
            var command = new SqlCommand
            {
                // returns 0 if article is unique
                CommandText = "check_article_uniqueness",
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@Title", title));
            var returnParameter = command.Parameters.Add("RetVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            var reader = DbHelper.ExecuteReader(ConnectionString, command);
            var id = (int)returnParameter.Value;
            reader.Close();
            return id == 0;
        }

        NewsCollection IChannelsDbService.GetChannelsFromDbByDate(string date)
        {
            return GetChannelsFromDbByDate(date);
        }
    }
}
