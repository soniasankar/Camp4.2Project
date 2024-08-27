using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ClinicalManagementSystem.Repository
{
    public class UsersRepository : IUsersRepository
    {
        // Sql Connection String
        private string conString = ConfigurationManager.ConnectionStrings["ConnectionStringWin"].ConnectionString;

        // Method for Authenticate User
        public int AuthenticateUser(string username, string password)
        {
            int roleId = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();

                    // Check UserName and Password
                    using (SqlCommand command = new SqlCommand("spGetUserNew", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // IN Parameters from stored procedure
                        command.Parameters.AddWithValue("@User", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Output Parameters
                        SqlParameter roleIdParam = new SqlParameter("@Rid", SqlDbType.Int);
                        roleIdParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(roleIdParam);

                        // Execute command
                        command.ExecuteNonQuery();

                        // Check Condition - if output parameter is DBNull before Conversion
                        if (command.Parameters["@Rid"].Value != DBNull.Value)
                        {
                            roleId = Convert.ToInt32(command.Parameters["@Rid"].Value);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Log SQL errors
                Console.WriteLine("SQL Error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                // Log general errors
                Console.WriteLine("Error: " + ex.Message);
            }

            return roleId;
        }
    }
}
