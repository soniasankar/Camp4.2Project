/*using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ClinicalManagementSystem.Model;
using ClinicalManagementSystem.Repository;
using ClinicalManagementSystem.Service;
using validation;

namespace ClinicalManagementSystem
{
    public class ReceptionistDashboard
    { 
        IReceptionistRepository receptionistRepository = null;
        IReceptionistService receptionistService = null;
        public ReceptionistDashboard()
        {
            //Call User Repository and User Service
            receptionistRepository = new ReceptionistRepository();
            receptionistService = new ReceptionistService(receptionistRepository);

        }
        public void Receptionistlist()
        {
            char choice = 'N';
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine(" Welcome Receptionist");

                    Console.WriteLine("Enter your choice:");
                    Console.WriteLine("1. Patient Management");
                    Console.WriteLine("2. Appointment Management");
                    Console.WriteLine("0. Logout");
                    Console.Write("Enter Your Choice: ");

                    int mainChoice = Convert.ToInt32(Console.ReadLine());
                    switch (mainChoice)
                    {
                        case 1: // Patient Management
                            Console.Clear();
                            Console.WriteLine(" Patient Management");
                            Console.WriteLine("1. Add Patient");
                            Console.WriteLine("2. Search Patient");
                            Console.WriteLine("3. Edit Patient");
                            Console.WriteLine("0. Back to Main Menu");
                            Console.Write("Enter Your Choice: ");

                            int patientChoice = Convert.ToInt32(Console.ReadLine());
                            switch (patientChoice)
                            {
                                case 1:
                                    PatientData();
                                    break;
                                case 2:
                                    SearchingPatientByPhonenumber();
                                    break;
                                case 3:
                                    EditPatientByPhonenumber();
                                    break;
                                case 0:
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice");
                                    break;
                            }
                            break;

                        case 2: // Appointment Management
                            Console.Clear();
                            Console.WriteLine(" Appointment Management");
                            Console.WriteLine("1. Add Appointment");
                            Console.WriteLine("0. Back to Main Menu");
                            Console.Write("Enter Your Choice: ");

                            int appointmentChoice = Convert.ToInt32(Console.ReadLine());
                            switch (appointmentChoice)
                            {
                                case 1:
                                    Console.Write("Enter Patient Name: ");
                                    string patientName = Console.ReadLine();
                                    Console.Write("Enter Registration Fees: ");
                                    int registrationFees = Convert.ToInt32(Console.ReadLine());
                                    BookAppointment(patientName, registrationFees);
                                    break;
                                case 0:
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice");
                                    break;
                            }
                            break;

                        case 0:
                            CMSApp app = new CMSApp();
                            app.LoginAppAsync();
                            return; // Exit the loop and method

                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.ReadLine(); // Clear the input buffer
                }

                Console.WriteLine("Do you want to return to the menu? (Y/N)");
                choice = Console.ReadLine().Trim().ToUpper()[0];
            } while (choice == 'Y');
        }

        //Methods for PatientData
        public void PatientData()
            {
            Console.WriteLine("Enter Patient Details");

        username:
            //username validation
            Console.Write("Enter Patient Name : ");
            string patientName = Console.ReadLine();
            bool isValidUsername = validations.IsValidUsername(patientName);
            if (!isValidUsername)
            {

                Console.WriteLine("Invalid User Name , Try Again");
                goto username;
            }
        dateofBirth:
            //Date of Birth validation
            Console.Write("Enter Patient DOB : ");
            string dob = Console.ReadLine();
           
           

           
        
        bool IsValidDOB = validations.IsValidDOB(dob);
        if (!IsValidDOB)
        {

            Console.WriteLine("Invalid DOB , Try Again");
            goto dateofBirth;
        }
        
        address:
            //Address Validation
            Console.Write("Enter Patient City : ");
            string address = Console.ReadLine();
            bool IsValidAddress = validations.IsValidAddress(address);
            if (!IsValidAddress)
            {

                Console.WriteLine("Invalid address , Try Again");
                goto address;
            }
        bloodgroup:
            //Blood Validations
            //Console.Write("Enter Patient Bloodgroup : ");
            string bloodGroup = "";
            Console.Write("Enter Patient Blood group: ");
            do
            {
                Console.WriteLine("Select your blood group:");
                Console.WriteLine("1. A+");
                Console.WriteLine("2. A-");
                Console.WriteLine("3. B+");
                Console.WriteLine("4. B-");
                Console.WriteLine("5. AB+");
                Console.WriteLine("6. AB-");
                Console.WriteLine("7. O+");
                Console.WriteLine("8. O-");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        bloodGroup = "A+";
                        break;
                    case 2:
                        bloodGroup = "A-";
                        break;
                    case 3:
                        bloodGroup = "B+";
                        break;
                    case 4:
                        bloodGroup = "B-";
                        break;
                    case 5:
                        bloodGroup = "AB+";
                        break;
                    case 6:
                        bloodGroup = "AB-";
                        break;
                    case 7:
                        bloodGroup = "O+";
                        break;
                    case 8:
                        bloodGroup = "O-";
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        continue;
                }
                bool IssValidBloodGroup = validations.isValidBloodGroup(bloodGroup);
                if (!IssValidBloodGroup)
                {

                    Console.WriteLine("Invalid Bloodgroup , Try Again");
                    goto bloodgroup;
                }
                break;

            } while (true);

        gender:
            //Gender validations
            Console.Write("Enter Patient gender : ");
            string gender = "";

            Console.WriteLine("Select your gender:");
            Console.WriteLine("1. Male");
            Console.WriteLine("2. Female");
            Console.WriteLine("3. Other");

            do
            {
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        gender = "Male";
                        break;
                    case 2:
                        gender = "Female";
                        break;
                    case 3:
                        gender = "Other";
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        continue;
                }
                bool IssValidGender = validations.isValidGender(gender);
                if (!IssValidGender)
                {

                    Console.WriteLine("Invalid Gender , Try Again");
                    goto gender;
                }
                break;

            } while (true);
        email:
            //email validation
            Console.Write("Enter Patient email : ");
            string email = Console.ReadLine();
            bool IsValidEmail = validations.IsValidEmail(email);
            if (!IsValidEmail)
            {

                Console.WriteLine("Invalid User Name , Try Again");
                goto email;
            }
        phonenumber:
            //email validations
            Console.Write("Enter Patient phoneNumber : ");
            string phonenumber = Console.ReadLine();
            bool IsValidPhoneNumber = validations.IsValidPhoneNumber(phonenumber);
            if (!IsValidPhoneNumber)
            {

                Console.WriteLine("Invalid  phonenumber, Try Again");
                goto phonenumber;
            }          
                //IReceptionistRepository receptionistRepository = new ReceptionistRepository();
                //IReceptionistService receptionistService = new ReceptionistService(receptionistRepository);
                //ReceptionistDashboard receptionistDashboard= new ReceptionistDashboard();
            Patient patient = new Patient(patientName, dob, address, bloodGroup, gender, email, phonenumber);
            ReceptionistDashboard receptionistDashboard = new ReceptionistDashboard();
            receptionistDashboard.receptionistService.AddPatientService(patient);
            Console.WriteLine("Patient Added Successfully");

            // Show menu after patient is added
            ShowMenu();
        }

        // Method to display the menu and handle further operations
        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\nReceptionist Menu:");
                Console.WriteLine("1. Add Another Patient");
                Console.WriteLine("2. Book Appointments");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        PatientData(); 
                        break;
                    case 2:
                        Console.Write("Enter Patient Name: ");
                        string patientName = Console.ReadLine();
                        Console.Write("Enter Registration Fees: ");
                        int registrationFees = Convert.ToInt32(Console.ReadLine());
                        BookAppointment(patientName, registrationFees);
                        break;
                    case 3:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        public void SearchingPatientByPhonenumber()
        {
            //IReceptionistRepository receptionistRepository = new ReceptionistRepository();
            //IReceptionistService receptionistService = new ReceptionistService(receptionistRepository);
            Console.WriteLine("Enter the phone number to search");
            //string patientName = Console.ReadLine();
            string phonenumber = Console.ReadLine();
            //ReceptionistDashboard receptionistDashboard = new ReceptionistDashboard();
            new ReceptionistDashboard().receptionistService.searchpatientsService(phonenumber);
          
        }
        public void EditPatientByPhonenumber()
        {
            //IReceptionistRepository receptionistRepository = new ReceptionistRepository();
            //IReceptionistService receptionistService = new ReceptionistService(receptionistRepository);
            Console.WriteLine("Enter the phone Number ");
            string phonenumber = Console.ReadLine();
            Console.WriteLine("Enter the NewAddress");
            string address = Console.ReadLine();
            new ReceptionistDashboard().receptionistService.EditpatientsService(phonenumber);
            Console.WriteLine("Patient edited successfully");
        }
     /*public void patientlist()
        {
            IReceptionistRepository receptionistRepository = new ReceptionistRepository();
            IReceptionistService receptionistService = new ReceptionistService(receptionistRepository);
            receptionistService.ListpatientsService();
            Console.WriteLine("patient list");
        }-----



        public void BookAppointment(string patientName, int registrationFees)
        {
            // Display the list of doctors
            new ReceptionistDashboard().receptionistService.ListDoctorService();

            // Input Doctor ID
            Console.WriteLine("Enter the Doctor id");
            int doctorId = Convert.ToInt32(Console.ReadLine());
            bool isValidDoctorId = validations.IsValidDoctorID(doctorId);
            if (!isValidDoctorId)
            {
                Console.WriteLine("Invalid Doctor ID, Try Again");
                return;
            }

            // Input Reason for Appointment
            Console.WriteLine("Enter the Reason for Appointment");
            string appointmentReason = Console.ReadLine();
            bool isValidReasonForAppointment = validations.IsValidReasonForAppointment(appointmentReason);
            if (!isValidReasonForAppointment)
            {
                Console.WriteLine("Invalid reason, Try Again");
                return;
            }

            // Input Appointment Date
            DateTime appointmentDateTime;
            Console.WriteLine("Select Appointment Date:");
            Console.WriteLine($"1 :{DateTime.Now.ToString("dd-MM-yyyy")}");
            Console.WriteLine($"2 :{DateTime.Now.AddDays(1).ToString("dd-MM-yyyy")}");
            Console.WriteLine($"3 :{DateTime.Now.AddDays(2).ToString("dd-MM-yyyy")}");
            Console.WriteLine($"4 :{DateTime.Now.AddDays(3).ToString("dd-MM-yyyy")}");
            Console.WriteLine($"5 :{DateTime.Now.AddDays(4).ToString("dd-MM-yyyy")}");
            int dateChoice = Convert.ToInt32(Console.ReadLine());
            switch (dateChoice)
            {
                case 1:
                    appointmentDateTime = DateTime.Now.Date;
                    break;
                case 2:
                    appointmentDateTime = DateTime.Now.AddDays(1).Date;
                    break;
                case 3:
                    appointmentDateTime = DateTime.Now.AddDays(2).Date;
                    break;
                case 4:
                    appointmentDateTime = DateTime.Now.AddDays(3).Date;
                    break;
                case 5:
                    appointmentDateTime = DateTime.Now.AddDays(4).Date;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            // Input Appointment Time
            Console.WriteLine("Select Appointment Time:");
            Console.WriteLine("1. 10:00AM-11:00AM");
            Console.WriteLine("2. 11:00AM-12:00PM");
            Console.WriteLine("3. 01:00PM-02:00PM");
            Console.WriteLine("4. 02:00PM-03:00PM");
            Console.WriteLine("5. 03:00PM-04:00PM");
            Console.WriteLine("6. 04:00PM-05:00PM");
            int timeChoice = Convert.ToInt32(Console.ReadLine());
            string appointmentTimeString = "";
            switch (timeChoice)
            {
                case 1:
                    appointmentTimeString = "10:00:00";
                    break;
                case 2:
                    appointmentTimeString = "11:00:00";
                    break;
                case 3:
                    appointmentTimeString = "12:00:00";
                    break;
                case 4:
                    appointmentTimeString = "13:00:00";
                    break;
                case 5:
                    appointmentTimeString = "14:00:00";
                    break;
                case 6:
                    appointmentTimeString = "15:00:00";
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            // Convert string time to TimeSpan
            TimeSpan appointmentTime;
            if (!TimeSpan.TryParse(appointmentTimeString, out appointmentTime))
            {
                Console.WriteLine("Invalid time format.");
                return;
            }

            // Convert DateTime to string if required
            string appointmentDate = appointmentDateTime.ToString("yyyy-MM-dd");

            // Generate Numeric Token within the range 1 to 100
            Random random = new Random();
            int token = random.Next(1, 101);

            // Create the Appointment object
            Appointment appointment = new Appointment(patientName, doctorId, appointmentReason, appointmentDate, appointmentTime, token);

            // Save Appointment
            new ReceptionistDashboard().receptionistService.AppointmentService(appointment, registrationFees);

            Console.WriteLine("Appointment Booked successfully");
            Console.WriteLine($"Your appointment token is: {token}");

            // Generate and display the bill
            
        }
       

            //methods for generatebill
/*
            public void GenerateBills(int doctorid, string Patientname, int registrationfees,string appointmentDate)
            {
                Console.WriteLine("Consulting Fees :");

                int consultingfees = receptionistService.GenerateBillservice(doctorid);

                string doctorname = receptionistService.Billservice(doctorid);


                int Totalfees = consultingfees + registrationfees;

                Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Doctorid    |  PatientName   | DoctorName | AppointmentDate | ConsultingFees | RegistrationFees | TotalFees");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"{doctorid,-11} | {Patientname,-13} | {doctorname,-10} | {appointmentDate,-15} | {consultingfees,-15} | {registrationfees,-16} | {Totalfees,-14}");

            }
           
        */

using System;
using ClinicalManagementSystem.Model;
using ClinicalManagementSystem.Repository;
using ClinicalManagementSystem.Service;
using validation;

namespace ClinicalManagementSystem
{
    public class ReceptionistDashboard
    {
        private readonly IReceptionistRepository _receptionistRepository;
        private readonly IReceptionistService _receptionistService;

        public ReceptionistDashboard()
        {
            _receptionistRepository = new ReceptionistRepository();
            _receptionistService = new ReceptionistService(_receptionistRepository);
        }

        public void Receptionistlist()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("                   ===========================================          ");
                Console.WriteLine("                             Welcome, Receptionist                      ");
                Console.WriteLine("                   ===========================================          ");
                Console.WriteLine("1. Patient Management");
                Console.WriteLine("2. Appointment Management");
                Console.WriteLine("0. Logout");
                Console.Write("Enter Your Choice: ");

                if (!int.TryParse(Console.ReadLine(), out int mainChoice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                switch (mainChoice)
                {
                    case 1:
                        HandlePatientManagement();
                        break;
                    case 2:
                        HandleAppointmentManagement();
                        break;
                    case 0:
                        Console.WriteLine("Logging out...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                Console.WriteLine("Do you want to return to the menu? (Y/N)");
                if (Console.ReadLine().Trim().ToUpper() != "Y")
                {
                    break;
                }
            }
        }

        private void HandlePatientManagement()
        {
            Console.Clear();
            Console.WriteLine("                         ===========================================                ");
            Console.WriteLine("                                  Patient Management                                ");
            Console.WriteLine("                         ===========================================                ");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. Search Patient");
            Console.WriteLine("3. Edit Patient");
            Console.WriteLine("0. Back to Main Menu");
            Console.Write("Enter Your Choice: ");

            if (!int.TryParse(Console.ReadLine(), out int patientChoice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            switch (patientChoice)
            {
                case 1:
                    PatientData();
                    break;
                case 2:
                    SearchingPatientByPhonenumber();
                    break;
                case 3:
                    EditPatientByPhonenumber();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }

        private void HandleAppointmentManagement()
        {
            Console.Clear();
            Console.WriteLine("                          ===========================================                  ");
            Console.WriteLine("                                  Appointment Management                               ");
            Console.WriteLine("                          ===========================================                  ");
            Console.WriteLine("1. Add Appointment");
            Console.WriteLine("0. Back to Main Menu");
            Console.Write("Enter Your Choice: ");

            if (!int.TryParse(Console.ReadLine(), out int appointmentChoice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            switch (appointmentChoice)
            {
                case 1:
                    Console.Write("Enter Patient Name: ");
                    string patientName = Console.ReadLine();
                    Console.Write("Enter Registration Fees: ");
                    if (!int.TryParse(Console.ReadLine(), out int registrationFees))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        return;
                    }
                    BookAppointment(patientName, registrationFees);
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }

        public void PatientData()
        {
            Console.Clear();
            Console.WriteLine("                     ===========================================        ");
            Console.WriteLine("                                 Add Patient                            ");
            Console.WriteLine("                     ===========================================         ");

            string patientName = GetValidatedInput("Enter Patient Name: ", validations.IsValidUsername, "Invalid User Name. Try Again");
            string dob = GetValidatedInput("Enter Patient DOB (yyyy-MM-dd): ", validations.IsValidDOB, "Invalid DOB. Try Again");
            string address = GetValidatedInput("Enter Patient City: ", validations.IsValidAddress, "Invalid Address. Try Again");

            string bloodGroup = GetValidatedBloodGroup();
            string gender = GetValidatedGender();
            string email = GetValidatedInput("Enter Patient Email: ", validations.IsValidEmail, "Invalid Email. Try Again");
            string phoneNumber = GetValidatedInput("Enter Patient Phone Number: ", validations.IsValidPhoneNumber, "Invalid Phone Number. Try Again");

            var patient = new Patient(patientName, dob, address, bloodGroup, gender, email, phoneNumber);
            _receptionistService.AddPatientService(patient);
            Console.WriteLine("Patient Added Successfully");
        }

        private string GetValidatedInput(string prompt, Func<string, bool> validationFunction, string errorMessage)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (validationFunction(input))
                {
                    return input;
                }
                Console.WriteLine(errorMessage);
            }
        }

        private string GetValidatedBloodGroup()
        {
            while (true)
            {
                Console.WriteLine("Select your blood group:");
                Console.WriteLine("1. A+");
                Console.WriteLine("2. A-");
                Console.WriteLine("3. B+");
                Console.WriteLine("4. B-");
                Console.WriteLine("5. AB+");
                Console.WriteLine("6. AB-");
                Console.WriteLine("7. O+");
                Console.WriteLine("8. O-");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 8)
                {
                    string[] bloodGroups = { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };
                    string bloodGroup = bloodGroups[choice - 1];
                    if (validations.isValidBloodGroup(bloodGroup))
                    {
                        return bloodGroup;
                    }
                }
                Console.WriteLine("Invalid choice. Please select a valid option.");
            }
        }

        private string GetValidatedGender()
        {
            while (true)
            {
                Console.WriteLine("Select your gender:");
                Console.WriteLine("1. Male");
                Console.WriteLine("2. Female");
                Console.WriteLine("3. Other");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 3)
                {
                    string[] genders = { "Male", "Female", "Other" };
                    string gender = genders[choice - 1];
                    if (validations.isValidGender(gender))
                    {
                        return gender;
                    }
                }
                Console.WriteLine("Invalid choice. Please select a valid option.");
            }
        }

        public void SearchingPatientByPhonenumber()
        {
            Console.Clear();
            Console.WriteLine("                         ===========================================                 ");
            Console.WriteLine("                                     Search Patient                                  ");
            Console.WriteLine("                         ===========================================                 ");
            Console.Write("Enter the phone number to search: ");
            string phoneNumber = Console.ReadLine();
            _receptionistService.searchpatientsService(phoneNumber);
        }

        public void EditPatientByPhonenumber()
        {
            Console.Clear();
            Console.WriteLine("                         ===========================================                    ");
            Console.WriteLine("                                     Edit Patient                                       ");
            Console.WriteLine("                         ===========================================                    ");




            Console.Write("Enter the phone number of the patient to edit: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter the New Address: ");
            string newAddress = Console.ReadLine();
            _receptionistService.EditpatientsService(phoneNumber);
            Console.WriteLine("Patient updated successfully");
        }

        public void BookAppointment(string patientName, int registrationFees)
        {
            Console.Clear();
            Console.WriteLine("                          ===========================================           ");
            Console.WriteLine("                                     Book Appointment");
            Console.WriteLine("                          ===========================================           ");

            _receptionistService.ListDoctorService();
            Console.Write("Enter the Doctor ID: ");
            if (!int.TryParse(Console.ReadLine(), out int doctorId) || !validations.IsValidDoctorID(doctorId))
            {
                Console.WriteLine("Invalid Doctor ID. Try Again.");
                return;
            }

 string appointmentReason = GetValidatedInput("Enter the Reason for Appointment: ", validations.IsValidReasonForAppointment, "Invalid reason. Try Again.");

            DateTime appointmentDate = GetValidatedDate();
            TimeSpan appointmentTime = GetValidatedTime();

            string appointmentDateStr = appointmentDate.ToString("yyyy-MM-dd");
            int token = new Random().Next(1, 101);

            var appointment = new Appointment(patientName, doctorId, appointmentReason, appointmentDateStr, appointmentTime, token);
            _receptionistService.AppointmentService(appointment, registrationFees);

            Console.WriteLine("Appointment Booked Successfully");
            Console.WriteLine($"Your appointment token is: {token}");
        }

        private DateTime GetValidatedDate()
        {
            while (true)
            {
                Console.WriteLine("Select Appointment Date:");
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{i + 1}: {DateTime.Now.AddDays(i).ToString("dd-MM-yyyy")}");
                }
                if (int.TryParse(Console.ReadLine(), out int dateChoice) && dateChoice >= 1 && dateChoice <= 5)
                {
                    return DateTime.Now.AddDays(dateChoice - 1).Date;
                }
                Console.WriteLine("Invalid choice. Please select a valid date.");
            }
        }

        private TimeSpan GetValidatedTime()
        {
            while (true)
            {
                Console.WriteLine("Select Appointment Time:");
                Console.WriteLine("1. 10:00AM-11:00AM");
                Console.WriteLine("2. 11:00AM-12:00PM");
                Console.WriteLine("3. 01:00PM-02:00PM");
                Console.WriteLine("4. 02:00PM-03:00PM");
                Console.WriteLine("5. 03:00PM-04:00PM");
                Console.WriteLine("6. 04:00PM-05:00PM");
                if (int.TryParse(Console.ReadLine(), out int timeChoice) && timeChoice >= 1 && timeChoice <= 6)
                {
                    string[] times = { "10:00:00", "11:00:00", "12:00:00", "13:00:00", "14:00:00", "15:00:00" };
                    if (TimeSpan.TryParse(times[timeChoice - 1], out TimeSpan appointmentTime))
                    {
                        return appointmentTime;
                    }
                }
                Console.WriteLine("Invalid choice. Please select a valid time.");
            }
        }
    }
}
