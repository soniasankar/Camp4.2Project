using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicalManagementSystem.Model;

namespace ClinicalManagementSystem.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        //Sql Connection String
        private string conString = ConfigurationManager.ConnectionStrings["ConnectionstringWin"].ConnectionString;

        //Method for Listappointment
        public void ListAppointment()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("spGetAppointmentsForToday", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {                          
                            if (reader.HasRows)
                            {
                                Console.WriteLine("{0,-6} | {1,-20} | {2,-9} | {3,-20} | {4,-15} | {5,-11} |", "Token", "PatientName", "DoctorID", "ReasonForAppointment", "AppointmentDate", "AppointmentTime");
                                Console.WriteLine("---------------------------------------------------------------------------------------------------");

                                while (reader.Read())
                                {
                                    Console.WriteLine("{0,-6} | {1,-20} | {2,-9} | {3,-20} | {4,-15} | {5,-11} |",
                                                      reader["Token"], reader["PatientName"], reader["DoctorID"], reader["ReasonForAppointment"], reader["AppointmentDate"], reader["AppointmentTime"]);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No appointment data found for today."); 
                            }
                            
                        }
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
        //Methods for AddDiagnosisRepository
        public void AddDiagnosisRepository(Diagnosis diagnosis)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                //Add Patient Procedure
                SqlCommand command = new SqlCommand("InsertDiagnosis", connection);
                command.CommandType = CommandType.StoredProcedure;

                //IN Parameters from stored procedure
                command.Parameters.AddWithValue("@AppointmentId", diagnosis.AppointmentId);
                command.Parameters.AddWithValue("@PatientName", diagnosis.PatientName);
                command.Parameters.AddWithValue("@DoctorId", diagnosis.DoctorId);
                command.Parameters.AddWithValue("@Symptoms", diagnosis.Symptoms);
                command.Parameters.AddWithValue("@DiagnosisDetails", diagnosis.DiagnosisDetails);
                command.Parameters.AddWithValue("@MedicineName", diagnosis.MedicineName);
                command.Parameters.AddWithValue("@Dosage", diagnosis.Dosage);
                command.Parameters.AddWithValue("@Course", diagnosis.Course);

                command.Parameters.AddWithValue("@TestName", diagnosis.TestName);
                command.ExecuteNonQuery();
            }
        }
        //Methods for MedicineList
        public void MedicineList()
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                //Create object for SqlDataAdapter,pass,query,connection
                SqlDataAdapter sda = new SqlDataAdapter("spMedicine", connection);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;

                //Step 4 - DataSet : Create a dataset and using fill() it with data from the SqlDataAdapter object
                DataTable dataSet = new DataTable();
                sda.Fill(dataSet);
                //Iterate

                Console.WriteLine("{0,-10} |", "Testname");
                Console.WriteLine("---------------------");

                foreach (DataRow row in dataSet.Rows)
                {
                    Console.WriteLine("{0,-10} |", row[0]);
                }

            }
        }
        //Methods for Doctorname
        public int Doctorname(int appointmentId)
        {
            int docId = 0;

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                // Prepare the command object
                SqlCommand command = new SqlCommand("spGetDoctorIDByToken", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Input Parameter for Appointment ID
                command.Parameters.AddWithValue("@TokenID", appointmentId);

                // Execute the command and get the result
                object result = command.ExecuteScalar();

                // Retrieve Doctor ID from the result
                if (result != DBNull.Value && result != null)
                {
                    docId = Convert.ToInt32(result);
                }
            }

            return docId;
        }
        //method for PatientRepository
        public string PatientRepository(int appointmentId)
        {
            string patient = "";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                // Check Patient Name by Appointment ID
                SqlCommand command = new SqlCommand("spGetPatientNameByToken", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Input Parameter for Appointment ID
                command.Parameters.AddWithValue("@TokenID", appointmentId);

                // Execute the command and get the result
                object result = command.ExecuteScalar();

                // Retrieve Patient Name from the result
                if (result != DBNull.Value)
                {
                    patient = Convert.ToString(result);
                }
            }
            return patient;
        }
        //method for TestList
        public void TestList()
        {                     
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    //Create object for SqlDataAdapter,pass,query,connection
                    SqlDataAdapter sda = new SqlDataAdapter("spTest", connection);
                    sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //Step 4 - DataSet : Create a dataset and using fill() it with data from the SqlDataAdapter object
                    DataTable dataSet = new DataTable();
                    sda.Fill(dataSet);
                    //Iterate

                    Console.WriteLine("{0,-10} ", "Testname");
                    Console.WriteLine("---------------------");

                    foreach (DataRow row in dataSet.Rows)
                    {
                        Console.WriteLine("{0,-10} ", row[0]);
                    }

                }
            
            
        }
        //Method for SearchPatientHistory
        public void SearchPatientHistory(string patientName)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                // Step 1: Get PatientId by PatientName
                SqlCommand getPatientIdCommand = new SqlCommand("spGetPatientIdByName", connection);
                getPatientIdCommand.CommandType = CommandType.StoredProcedure;
                getPatientIdCommand.Parameters.AddWithValue("@PatientName", patientName);

                object result = getPatientIdCommand.ExecuteScalar();

                int patientId;
                if (result != DBNull.Value && result != null)
                {
                    patientId = Convert.ToInt32(result);
                }
                else
                {
                    Console.WriteLine("Patient not found.");


                    return;
                }

                // Step 2: Fetch Patient Details using PatientId
                SqlCommand searchCommand = new SqlCommand("spFetchPatientDetails", connection);
                searchCommand.CommandType = CommandType.StoredProcedure;
                searchCommand.Parameters.AddWithValue("@PatientId", patientId);

                SqlDataReader reader = searchCommand.ExecuteReader();
                Console.WriteLine("---------------------------------------------------------------------------------------");
                Console.WriteLine($"{"DoctorName",-20}{"PatientName",-20}{"ReasonForAppointment",-25}{"MedicineName",-20}");
                Console.WriteLine("----------------------------------------------------------------------------------------");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["DoctorName"],-20}{reader["PatientName"],-20}{reader["ReasonForAppointment"],-25}{reader["MedicineName"],-20}");
                }

                if (!reader.HasRows)
                {
                    Console.WriteLine("No history found for this patient.");
                }

                reader.Close();
            }
        }
    }
           
        
            
           



    }




