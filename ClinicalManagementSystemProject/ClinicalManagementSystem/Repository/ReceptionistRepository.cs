using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ClinicalManagementSystem.Model;

namespace ClinicalManagementSystem.Repository
{
    public class ReceptionistRepository : IReceptionistRepository
    {

        //Sql Connection String
        private string conString = ConfigurationManager.ConnectionStrings["ConnectionStringWin"].ConnectionString;


        public void AddpatientsRepository(Patient patient)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                //Add Patient Procedure
                SqlCommand command = new SqlCommand("spAddPatient", connection);
                command.CommandType = CommandType.StoredProcedure;

                //IN Parameters from stored procedure
                command.Parameters.AddWithValue("@PatientName", patient.PatientName);
                command.Parameters.AddWithValue("@DOB", patient.DOB);
                command.Parameters.AddWithValue("@Address", patient.Address);
                command.Parameters.AddWithValue("@BloodGroup", patient.Bloodgroup);
                command.Parameters.AddWithValue("@Gender", patient.Gender);
                command.Parameters.AddWithValue("@Email", patient.Email);
                command.Parameters.AddWithValue("@PhoneNumber", patient.Phonenumber);

                command.ExecuteNonQuery();
            }
        }


        public void Editpatients(string phonenumber)
        {

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                //Add Patient Procedure
                SqlCommand command = new SqlCommand("UpdateAddressByPhoneNumber", connection);
                command.CommandType = CommandType.StoredProcedure;
                Console.WriteLine("Enter the new address");
                string newaddress = Console.ReadLine();
                //IN Parameters from stored procedure
                command.Parameters.AddWithValue("@NewAddress", newaddress);
                command.Parameters.AddWithValue("@PhoneNumber", phonenumber);
                command.ExecuteNonQuery();
                Console.WriteLine("Patient address updated successfully.");


            }
        }
        /*public void Listpatients()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    //Create object for SqlDataAdapter,pass,query,connection
                    SqlDataAdapter sda = new SqlDataAdapter("spListPatient", connection);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;

                    //Step 4 - DataSet : Create a dataset and using fill() it with data from the SqlDataAdapter object
                    DataTable dataSet = new DataTable();
                    sda.Fill(dataSet);
                    //Iterate
                   
                    Console.WriteLine($"patientid | patientname  |  DOB   |  Address   |  Bloodgroup   |  Gender  | Email | Phonenumber |  ");
                    Console.WriteLine("----------------------------------------------------------------------------------------------------");
                    foreach (DataRow row in dataSet.Rows)
                    {
                        
                        Console.WriteLine($"{row[0]}\t|{row[1]}\t|{row[2]}\t|{row[3]}\t|{row[4]}\t|{row[5]}\t|{row[6]}\t|{row[7]}|");
                    }
                    

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Sql Exception : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }*/


        /*public void searchpatients(string phoneNumber)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    if (connection != null)
                        connection.Open();
                    //serachstring
                    string query = "spSearchByNumber";
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    //reading
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    Console.WriteLine($"PatientId || PatientName ||      DOB       ||   Bloodgroup ||  Gender  ||    Address     ||   Email || PhoneNumber");
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------");
                    while (reader.Read())
                    {

                        Console.WriteLine($"{reader[0],-8} {reader[1],-9} {reader[2],-8} {reader[3],-9}{reader[4],-9} {reader[5],-8} {reader[6],-8} {reader[7],-8}");
                    }
                    reader.Close();
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Sql Exception : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }*/
        public void ListDoctor()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    //Create object for SqlDataAdapter,pass,query,connection
                    SqlDataAdapter sda = new SqlDataAdapter("spListDoctors", connection);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;

                    //Step 4 - DataSet : Create a dataset and using fill() it with data from the SqlDataAdapter object
                    DataTable dataSet = new DataTable();
                    sda.Fill(dataSet);
                    //Iterate
                    Console.WriteLine("-----------------------------------------------------------------------");
                    Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-15} |", "DoctorID", "DoctorName", "Specialization", "ConsultingFees");
                    Console.WriteLine("-----------------------------------------------------------------------");

                    foreach (DataRow row in dataSet.Rows)
                    {
                        Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-15} |", row[0], row[1], row[2], row[3]);
                    }



                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Sql Exception : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void SearchAndEditPatient(string phoneNumber)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    if (connection != null)
                        connection.Open();

                    // Search for the patient
                    string searchQuery = "spSearchByNumber";
                    SqlCommand searchCommand = new SqlCommand(searchQuery, connection);
                    searchCommand.CommandType = CommandType.StoredProcedure;
                    searchCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    // Execute search query

                    SqlDataReader reader = searchCommand.ExecuteReader();
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"{"PatientId",-10}{"PatientName",-15}{"DOB",-12}{"Address",-12}{"BloodGroup",-12}{"Gender",-8}{"Email",-20}{"PhoneNumber",-15}");
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0],-10}{reader[1],-15}{reader[2],-12}{reader[3],-12}{reader[4],-12}{reader[5],-8}{reader[6],-20}{reader[7],-15}");
                    }


                    // Check if patient found
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("Patient not found.");
                        reader.Close();
                        return;// Close the reader here                    
                    }
                    Console.ReadKey();
                    // Close the reader after checking for rows
                    reader.Close();
                    string searchquery = "spName";
                    SqlCommand searchCommands = new SqlCommand(searchquery, connection);
                    searchCommands.CommandType = CommandType.StoredProcedure;
                    searchCommands.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    string spname = (string)searchCommands.ExecuteScalar();
                    // Ask if user wants to edit patient
                    /*Console.WriteLine("Do you want to edit this patient? (yes/no):");
                    string choice = Console.ReadLine().ToLower();
                    if (choice == "yes")
                    {
                        // Get new address from user
                        Console.WriteLine("Enter the new address:");
                        string newAddress = Console.ReadLine();

                        // Update patient's address
                        SqlCommand editCommand = new SqlCommand("UpdateAddressByPhoneNumber", connection);
                        editCommand.CommandType = CommandType.StoredProcedure;
                        editCommand.Parameters.AddWithValue("@NewAddress", newAddress);
                        editCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        editCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        Console.WriteLine("Patient details not edited.");
                    }*/
                    connection.Close();
                    // Ask if user wants to edit patient or book appointment
                    Console.WriteLine("Do you want to Edit or Book Appointment?(Yes/no):");
                    string menu = Console.ReadLine().ToLower();
                    if (menu == "yes")
                    {
                        char choice = 'N';
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Enter your choice");
                            Console.WriteLine("1.Edit Patient");
                            Console.WriteLine("2.Book Appointment");
                            int Choice = Convert.ToInt32(Console.ReadLine());
                            switch (Choice)
                            {
                                case 1:
                                    Editpatients(phoneNumber);
                                    break;
                                case 2:

                                    ReceptionistDashboard receptionistDashboard = new ReceptionistDashboard();
                                    receptionistDashboard.BookAppointment(spname, 0);
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice");
                                    break;
                            }
                            Console.WriteLine("Do you want to go to menu driven?(Y/N)");
                            choice = Console.ReadLine().Trim().ToUpper()[0];
                        } while (choice == 'Y');
                    }
                }
                }
            catch (SqlException ex)
            {
                Console.WriteLine("Sql Exception : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        //Sql Connection String
        //private string conString = ConfigurationManager.ConnectionStrings["ConnectionStringWin"].ConnectionString;
        /*
        //Method for Authenticate User
        public int GenerateBill(int doctorid)
        {
            int fees = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                //Check UserName and Password
                SqlCommand command = new SqlCommand("spBill", connection);
                command.CommandType = CommandType.StoredProcedure;

                //IN Parameters from stored procedure
                command.Parameters.AddWithValue("@DoctorID", doctorid);


                //Output Parameters
                SqlParameter roleIdParam = new SqlParameter("@ConsultingFees", System.Data.SqlDbType.Int);
                roleIdParam.Direction = System.Data.ParameterDirection.Output;
                command.Parameters.Add(roleIdParam);
                command.ExecuteNonQuery();
                //Check Condition - if ouput parameter is DBNull before Conversion
                if (command.Parameters["@ConsultingFees"].Value != DBNull.Value)
                {
                    fees = Convert.ToInt32(command.Parameters["@ConsultingFees"].Value);

                }
            }
            return fees;
        }
        */


        public int GetPatientIdByName(string patientName)
        {
            // Implement the logic to retrieve the patient ID by name
            // Placeholder logic for demonstration
            // In a real scenario, this would involve querying your database

            // Example logic
            // Assuming you have a database connection and a `Patients` table
            string query = "SELECT PatientId FROM Patient WHERE PatientName = @PatientName";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand(query ,connection );
                cmd.Parameters.AddWithValue("@PatientName", patientName);

                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int patientId))
                {
                    return patientId;
                }
                else
                {
                    return -1; // Return -1 if patient ID is not found
                }
            }
        }
                public int GenerateBill(int patientId, int doctorId)
        {
            int fees = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                // Prepare the command
                SqlCommand command = new SqlCommand("spBill", connection);
                command.CommandType = CommandType.StoredProcedure;

                // IN Parameters
                command.Parameters.AddWithValue("@PatientId", patientId);
                command.Parameters.AddWithValue("@DoctorID", doctorId);

                // Output Parameter
                SqlParameter consultingFeesParam = new SqlParameter("@ConsultingFees", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(consultingFeesParam);

                // Execute the command
                command.ExecuteNonQuery();

                // Get the output parameter value
                if (consultingFeesParam.Value != DBNull.Value)
                {
                    fees = Convert.ToInt32(consultingFeesParam.Value);
                }
            }
            return fees;
        }

        public string Billrepository(int doctorid)
        {
            string doctorname = "";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("spGetDoctorNames", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@DoctorID", doctorid);

                // Execute the stored procedure
                doctorname = command.ExecuteScalar()?.ToString();

                return doctorname;
            }
        }

        public void AppointmentRepository(Appointment appointment, int registration)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();

                    // Add Appointment Procedure
                    SqlCommand command = new SqlCommand("spAddAppointment", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // IN Parameters from stored procedure
                    command.Parameters.AddWithValue("@PatientName", appointment.PatientName);
                    command.Parameters.AddWithValue("@DoctorID", appointment.DoctorID);
                    command.Parameters.AddWithValue("@ReasonForAppointment", appointment.ReasonForAppointment);
                    command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    command.Parameters.AddWithValue("@AppointmentTime", appointment.AppointmentTime);
                   
                    // Execute the stored procedure
                    command.ExecuteNonQuery();

                    
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Sql Exception : " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
       


    }


}

    




