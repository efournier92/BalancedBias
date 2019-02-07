using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BalancedBias.Common.Config;
using BalancedBias.Common.Connectivity;

namespace BalancedBias.Rss
{
    public class ChannelsDbService
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["channelsDb"].ConnectionString;

        public static void AddNewArticle(string channel, string title, string url, string publishDate, string description)
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

            if (IsArticleUnique(title))
            {
                var reader = DbHelper.ExecuteReader(ConnectionString, command);
                reader.Close();
            }
        }

        public static NewsCollection GetAllChannelsFromDb()
        {
            var config = ConfigurationManager.GetSection("rssService") as RssServiceSection;
            var newsCollection = new NewsCollection();
            if (config == null) return newsCollection;
            foreach (ChannelElement channel in config.Channels)
            {
                newsCollection.Channels.Add(GetArticlesByChannel(channel));
            }

            return newsCollection;
        }

        public static NewsCollection GetChannelsFromDbByDate(string date)
        {
            var config = ConfigurationManager.GetSection("rssService") as RssServiceSection;
            var newsCollection = new NewsCollection();
            if (config == null) return newsCollection;
            foreach (ChannelElement channel in config.Channels)
            {
                newsCollection.Channels.Add(GetArticlesByDateAndChannel(channel, date));
            }

            return newsCollection;
        }


        public static List<string> GetUniqueArticleDates()
        {
            var uniqueDates = new List<string>();
            var command = new SqlCommand
            {
                CommandText = "get_all_stored_dates",
                CommandType = CommandType.StoredProcedure
            };
            var reader = DbHelper.ExecuteReader(ConnectionString, command) as SqlDataReader;
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

        public static Channel GetArticlesByDateAndChannel(ChannelElement channelElement, string publishDate)
        {
            var channel = new Channel();
            channel.Name = channelElement.Name;
            channel.Icon = channelElement.Icon;

            var command = new SqlCommand
            {
                CommandText = "get_articles_by_date_and_channel",
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@Channel", channel.Name));
            command.Parameters.Add(new SqlParameter("@Date", publishDate));
            var reader = DbHelper.ExecuteReader(ConnectionString, command) as SqlDataReader;
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

        public static Channel GetArticlesByChannel(ChannelElement channelElement)
        {
            var channel = new Channel();
            channel.Name = channelElement.Name;
            channel.Icon = channelElement.Icon;

            var command = new SqlCommand
            {
                CommandText = "get_articles_by_channel",
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@Channel", channel.Name));
            var reader = DbHelper.ExecuteReader(ConnectionString, command) as SqlDataReader;
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
            channel.Articles = channel.Articles.OrderByDescending(c => c.PublishDate).ToList();
            return channel;
        }

        public static bool IsArticleUnique(string title)
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
            int id = (int)returnParameter.Value;
            reader.Close();
            return id == 0;
        }
    }
}
