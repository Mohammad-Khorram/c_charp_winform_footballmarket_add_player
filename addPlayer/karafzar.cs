using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace addPlayer
{
    class karafzar
    {
        public static SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionStringWeb"].ConnectionString);
        public static SqlCommand sqlCommand = new SqlCommand();
        public static SqlDataAdapter sqlDataAdapter;
        public static bool hasError;

        public static void ExecuteNonQuery()
        {
            sqlCommand.Connection = sqlConnection;

            try
            {
                sqlConnection.Open();

                if (sqlCommand.ExecuteNonQuery() > 0)
                    hasError = false;
                else
                    hasError = true;
            }
            catch
            {
                hasError = true;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Parameters.Clear();
            }
        }

        public static DataTable SqlDataAdapter()
        {
            DataTable dataTable = new DataTable();
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Close();

            try
            {
                sqlDataAdapter = new SqlDataAdapter();
                sqlCommand.Connection = sqlConnection;
                sqlDataAdapter.SelectCommand = sqlCommand;
                dataTable.Clear();
                sqlConnection.Open();
                sqlDataAdapter.Fill(dataTable);
                hasError = false;
                return dataTable;
            }
            catch
            {
                hasError = true;
                return null;
            }
            finally
            {
                sqlConnection.Close();
                sqlCommand.Parameters.Clear();
            }
        }
    }
}
