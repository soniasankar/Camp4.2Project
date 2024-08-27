using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ClinicalManagementSystem.Model;
using ClinicalManagementSystem.Repository;
using ClinicalManagementSystem.Service;
using validation;

namespace ClinicalManagementSystem
{


    /*
    public class CMSApp
    {
        static void Main(string[] args)
        {
            CMSApp app = new CMSApp();
            app.Loginapp();

        }
        public void Loginapp()
        {
        check://label
            Console.Clear();
            Console.WriteLine("WELCOME CLINICAL MANAGEMENT SYSTEM");
            Console.WriteLine(" LOGIN");
            Console.WriteLine("Enter username");
            string username = Console.ReadLine();
            //UI Validation
            bool isValidusername = validations.IsValidUsername(username);
            if (!isValidusername)
            {
                Console.WriteLine("invalid user name ,try again");
                goto check;
            }
        //password
        logincheck:
            Console.WriteLine("Enter password");
            //string password = Console.ReadLine();
            string password = validations.ReadPassword();
            //UI Validation
            bool isValidpassword = validations.IsvalidPassword(password);

            if (!isValidpassword)
            {
                Console.WriteLine("invalid password ,try again");
                goto logincheck;
            }
            //After validation
            if (isValidusername && isValidpassword)
            {
                IUsersRepository userRepository = new UsersRepository();
                IUsersService usersService = new UsersService(userRepository);
                int roleId = usersService.Authenticateuser(username, password);
                //show menu based role
                if (roleId >= 1)
                {
                    switch (roleId)
                    {
                        case 1:
                            //receptionistmenu
                            Console.WriteLine("\nReceptionist\n");
                            ReceptionistDashboard receptionistDashboard = new ReceptionistDashboard();
                            receptionistDashboard.Receptionistlist();
                            break;
                        case 2:
                            //doctor
                            Console.WriteLine("\nDoctor\n");
                            DoctorDashboard doctorDashboard = new DoctorDashboard();
                            doctorDashboard.Doctor();
                            break;

                        default:
                            Console.WriteLine("invalid menu");
                            break;
                    }
                }
            }


            Console.WriteLine("Invalid username or password  Try again");

            goto check;

        }
    }
    */

    /*
   
        public class CMSApp
        {
            static async Task Main(string[] args)
            {
                CMSApp app = new CMSApp();
                await app.LoginAppAsync();
            }

            public async Task LoginAppAsync()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("                                         ------------------");
                    Console.WriteLine("                                         *    L O G I N   *");
                    Console.WriteLine("                                         ------------------");

                    // UserName
                    Console.Write("Enter UserName  :  ");
                    string username = Console.ReadLine();

                    // Check validations
                    if (!validations.IsValidUsername(username))
                    {
                        Console.WriteLine("Invalid User Name, Try Again");
                        Console.WriteLine("Press any key to try again...");
                        Console.ReadKey(); // Wait for user to acknowledge the error
                        continue;
                    }

                    // Password
                    Console.Write("Enter Password  :  ");
                    string password = validations.ReadPassword();

                    // Check validations
                    if (!validations.IsvalidPassword(password))
                    {
                        Console.WriteLine("Invalid Password, Try Again");
                        Console.WriteLine("Press any key to try again...");
                        Console.ReadKey(); // Wait for user to acknowledge the error
                        continue;
                    }

                    // After UI validation
                    try
                    {
                        IUsersService loginService = new UsersService(new UsersRepository());
                        int roleId =  loginService.Authenticateuser(username, password);

                        // Dashboard
                        if (roleId >= 1)
                        {
                            switch (roleId)
                            {
                                case 1:
                                    // Receptionist
                                    Console.WriteLine("\nReceptionist\n");
                                    ReceptionistDashboard receptionistDashboard = new ReceptionistDashboard();
                                    receptionistDashboard.Receptionistlist(); // Assume ShowMenuAsync is an async method
                                    break;
                                case 2:
                                    // Doctor
                                    Console.WriteLine("\nDoctor\n");
                                    DoctorDashboard doctorDashboard = new DoctorDashboard();
                                     doctorDashboard.Doctor(); // Assume ShowMenuAsync is an async method
                                    break;
                                default:
                                    Console.WriteLine("Invalid role: ACCESS DENIED!");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid credentials");
                            Console.WriteLine("Press any key to try again...");
                            Console.ReadKey(); // Wait for user to acknowledge the error
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log or handle the exception as needed
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        Console.WriteLine("Press any key to try again...");
                        Console.ReadKey(); // Wait for user to acknowledge the error
                    }
                }
            }
    */
   
        public class CMSApp
        {
            static async Task Main(string[] args)
            {
                CMSApp app = new CMSApp();
                await app.LoginAppAsync();
            }

            public async Task LoginAppAsync()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("                             ===========================================                ");
                    Console.WriteLine("                                 WELCOME TO CLINICAL MANAGEMENT SYSTEM                   ");
                    Console.WriteLine("                             ===========================================                 ");
                    Console.WriteLine();
                    Console.WriteLine("                                            ** LOGIN **                                   ");
                    Console.WriteLine();

                    // UserName
                    Console.Write("Enter UserName: ");
                    string username = Console.ReadLine();

                    // Check validations
                    if (!validations.IsValidUsername(username))
                    {
                        Console.WriteLine("Invalid User Name. Please try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(); // Wait for user to acknowledge the error
                        continue;
                    }

                    // Password
                    Console.Write("Enter Password: ");
                    string password = validations.ReadPassword();

                    // Check validations
                    if (!validations.IsvalidPassword(password))
                    {
                        Console.WriteLine("Invalid Password. Please try again.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(); // Wait for user to acknowledge the error
                        continue;
                    }

                    // After UI validation
                    try
                    {
                        IUsersService userService = new UsersService(new UsersRepository());
                        int roleId = userService.Authenticateuser(username, password);

                        // Dashboard
                        if (roleId >= 1)
                        {
                            switch (roleId)
                            {
                                case 1:
                                    // Receptionist
                                    Console.Clear();
                                    Console.WriteLine("             ===========================================                    ");
                                    Console.WriteLine("                          RECEPTIONIST                                       ");
                                    Console.WriteLine("             ===========================================                   ");
                                    Console.WriteLine();
                                    ReceptionistDashboard receptionistDashboard = new ReceptionistDashboard();
                                    receptionistDashboard.Receptionistlist(); // Assume ShowMenuAsync is an async method
                                    break;
                                case 2:
                                    // Doctor
                                    Console.Clear();
                                    Console.WriteLine("           ===========================================                         ");
                                    Console.WriteLine("                    DOCTOR");
                                    Console.WriteLine("           ===========================================                          ");
                                    Console.WriteLine();
                                    DoctorDashboard doctorDashboard = new DoctorDashboard();
                                    doctorDashboard.Doctor(); // Assume ShowMenuAsync is an async method
                                    break;
                                default:
                                    Console.WriteLine("Invalid role. ACCESS DENIED!");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid credentials. Please try again.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey(); // Wait for user to acknowledge the error
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log or handle the exception as needed
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(); // Wait for user to acknowledge the error
                    }
                }
            }
        }
    }





