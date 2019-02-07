using System;
using System.Data;
using System.Data.SqlClient;

namespace BalancedBias.Common.Connectivity
{
    public class DbHelper
    {
        //public static void ExecuteReader(string connectionString, SqlCommand command)
        //{
        //    var connection = new SqlConnection(connectionString);

        //    try
        //    {
        //        ConfigureCommand(command, connection);
        //        connection.Open();
        //        command.ExecuteReader(CommandBehavior.CloseConnection);
        //        connection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        connection.Close();
        //        throw new Exception(connectionString , ex);
        //    }
        //}

        private static void ConfigureCommand(IDbCommand command, IDbConnection connection, CommandType commandType = CommandType.StoredProcedure)
        {
            command.Connection = connection;
            command.CommandType = commandType;
            if (commandType != CommandType.StoredProcedure) return;
            //command.CommandTimeout = 5000;
        }

        public static IDataReader ExecuteReader(string connectionString, SqlCommand command)
        {
            var connection = new SqlConnection(connectionString);

            try
            {
                ConfigureCommand(command, connection);
                connection.Open();
                //Connection will be closed when SqlDataReader close is called.
                return command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                connection.Close();
                throw new Exception("Reader Failed", ex);
                //throw new DatabaseException(BuildSqlQuery(command), ex);
            }
        }

        //public static IDataReader ExecuteReader(string connectionString, SqlCommand command)
        //{
        //    //var connection = new SqlConnection(connectionString);


        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        ConfigureCommand(command, connection);
        //        connection.Open();
        //        command.ExecuteReader(CommandBehavior.CloseConnection);
        //    }

            



        //    //try
        //    //{
        //    //    connection.Open();

        //    //    //Connection will be closed when SqlDataReader close is called.
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw new Exception("SQL Error", ex);
        //    //    //throw new DatabaseException(BuildSqlQuery(command), ex);
        //    //}
        //    ////finally
        //    //{
        //    //    connection.Close();
        //    //}
        //}
    }
}
