using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerConnectionManager
{
    public class SqlServerConnectionManager
    {
        public static SqlConnection OpenConnection(string conString)
        {
            SqlConnection connection = null;


            try
            {
                if (connection == null || Convert.ToString(connection.State) == "Closed")
                {
                    connection = new SqlConnection(conString);
                }
                return connection;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("oops,sql server error occured:");
                Console.WriteLine(ex.Message);
                return null;
            }

            catch (Exception ex)
            {
                Console.WriteLine("oops something went wrong.\n" + ex);
                return null;
            }


            Console.WriteLine("Press any key to exit..");
        }
        
    }
}
