using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
                DbHelper.ExecuteReader(ConnectionString, command);
            }
        }

        public static void GetArticlesByDate(DateTime publishDate)
        {
            var day = publishDate.Day;
            var month = publishDate.Month;
            var year = publishDate.Year;

            var command = new SqlCommand
            {
                CommandText = "get_articles_by_date",
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@Month", day));
            command.Parameters.Add(new SqlParameter("@Day", month));
            command.Parameters.Add(new SqlParameter("@Year", year));
            var reader = DbHelper.ExecuteReader(ConnectionString, command) as SqlDataReader;
            if (reader == null) return;
            var channelsList = new List<Article>();

            while (reader.Read())
            {
                var article = new Article
                {
                    Title = Convert.ToString(reader["title"].ToString()),
                    Url = string.IsNullOrEmpty(reader["url"].ToString())
                            ? ""
                            : reader["url"].ToString(),
                    PublishDate = Convert.ToString(reader["publishDate"].ToString()),
                    Body = Convert.ToString(reader["description"])
                };
                channelsList.Add(article);
            }
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
            DbHelper.ExecuteReader(ConnectionString, command);

            int id = (int)returnParameter.Value;
            return id == 0;
        }
    }
}
