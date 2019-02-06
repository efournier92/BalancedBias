using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BalancedBias.Common.Connectivity;

namespace BalancedBias.Rss
{
    public class FeedsDbService
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["FeedsDb"].ConnectionString;

        public static void AddNewFeedItem(string title, string link, string publishDate, string description)
        {
            var command = new SqlCommand
            {
                CommandText = "Set_Feed_Item",
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@Title", title));
            command.Parameters.Add(new SqlParameter("@Link", link));
            command.Parameters.Add(new SqlParameter("@PublishDate", publishDate));
            command.Parameters.Add(new SqlParameter("@Description", description));

            if (IsFeedItemUnique(title))
            {
                DbHelper.ExecuteReader(ConnectionString, command);
            }
        }

        public static void GetFeedItemsByDate(DateTime publishDate)
        {
            var day = publishDate.Day;
            var month = publishDate.Month;
            var year = publishDate.Year;

            var command = new SqlCommand
            {
                CommandText = "Get_Feed_Item_By_Date",
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@Month", day));
            command.Parameters.Add(new SqlParameter("@Day", month));
            command.Parameters.Add(new SqlParameter("@Year", year));
        }

        public static bool IsFeedItemUnique(string title)
        {
            var command = new SqlCommand
            {
                CommandText = "Get_Feed_Item_By_Title",
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@Title", title));
            SqlParameter returnParameter = command.Parameters.Add("RetVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            DbHelper.ExecuteReader(ConnectionString, command);

            int id = (int)returnParameter.Value;
            return id == 0;
        }
    }
}
