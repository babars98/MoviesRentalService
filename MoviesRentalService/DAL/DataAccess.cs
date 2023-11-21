using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace MoviesRentalService.DAL
{
    public class DataAccess
    {
        public DataTable ExecuteReadQuery(string query)
        {
            DataTable dt = new DataTable();
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandText = query;
                            cmd.CommandType = CommandType.Text;
                            connection.Open();
                            sda.Fill(dt);
                        }
                    }
                }
            }
            catch(Exception ex) { }

            return dt;
        }

        public bool ExecuteWriteQuery(string query, Dictionary<string, object> param)
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        foreach(KeyValuePair<string, object> keyVal in param)
                            command.Parameters.AddWithValue(keyVal.Key, keyVal.Value);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Check Error
                        if (result < 0)
                            return false;

                        return true;
                    }
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}