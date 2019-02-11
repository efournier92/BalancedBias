using System;
using System.Data;
using System.Data.SqlClient;

namespace BalancedBias.Common.Connectivity
{
    /// <summary>
    /// Database utility methods
    /// </summary>
    public class DbHelper
    {
        /// <summary>
        /// Configure SQL command for new DB connection
        /// </summary>
        /// <param name="command"></param>
        /// <param name="connection"></param>
        /// <param name="commandType"></param>
        private static void ConfigureCommand(IDbCommand command, IDbConnection connection, CommandType commandType = CommandType.StoredProcedure)
        {
            command.Connection = connection;
            command.CommandType = commandType;
        }

        /// <summary>
        /// Open new connection for database reader
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="command"></param>
        /// <returns>Reader for newly-opened SQL connection</returns>
        public static IDataReader ExecuteReader(string connectionString, SqlCommand command)
        {
            var connection = new SqlConnection(connectionString);

            try
            {
                ConfigureCommand(command, connection);
                connection.Open();
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                connection.Close();
                throw new Exception("Reader Failed", ex);
            }
        }
    }
}
