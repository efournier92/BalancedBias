using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BalancedBias.Common;
using BalancedBias.Common.Config.Sections;
using BalancedBias.Common.Connectivity;

namespace BalancedBias.Rss
{
    public class FeedsDbService
    {
        private static ConnectionStringServiceSection _connectionStringSection = ConfigurationManager.GetSection("connectionStrings") as ConnectionStringServiceSection;
        private string _connectionString = _connectionStringSection.ConnectionString;

        public static void AddNewFeedItem(string title, string link, string publishDate, string description)
        {
            var command = new SqlCommand
            {
                CommandText = "Set_Feed_Item",
                CommandType = CommandType.StoredProcedure
            };

            // Adding sql parameters
            command.Parameters.Add(new SqlParameter("@Title", title));
            command.Parameters.Add(new SqlParameter("@Link", link));
            command.Parameters.Add(new SqlParameter("@PublishDate", publishDate));
            command.Parameters.Add(new SqlParameter("@Description", description));
            DbHelper.ExecuteReader("Data Source=EFOURNIER-LT\\SQLEXPRESS;Initial Catalog=BalancedBias;Integrated Security=True;Connect Timeout=20;Encrypt=False;TrustServerCertificate=False", command);
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
            DbHelper.ExecuteReader("Data Source=EFOURNIER-LT\\SQLEXPRESS;Initial Catalog=BalancedBias;Integrated Security=True;Connect Timeout=20;Encrypt=False;TrustServerCertificate=False", command);
        }
    }
}
