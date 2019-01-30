using System;
using System.Data;
using System.Data.SqlClient;

namespace BalancedBias.Common.Connectivity
{
    public class DbHelper
    {
        public static void ExecuteReader(string connectionString, SqlCommand command)
        {
            var connection = new SqlConnection(connectionString);

            try
            {
                ConfigureCommand(command, connection);
                connection.Open();
                //Connection will be closed when SqlDataReader close is called.
                command.ExecuteReader(CommandBehavior.CloseConnection);
                connection.Close();
            }
            catch (System.Exception ex)
            {
                connection.Close();
                //return null;
                throw new Exception(connectionString , ex);
            }
        }

        private static void ConfigureCommand(IDbCommand command, IDbConnection connection, CommandType commandType = CommandType.StoredProcedure)
        {
            command.Connection = connection;
            command.CommandType = commandType;
            if (commandType != CommandType.StoredProcedure) return;
            //var timeout = CommandTimeoutSection.GetStoredProcTimeout(command.CommandText);
            command.CommandTimeout = 5000;
        }
    }
}
