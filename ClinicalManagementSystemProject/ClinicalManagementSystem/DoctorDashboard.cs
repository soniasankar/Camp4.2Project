using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ClinicalManagementSystem.Model;
using ClinicalManagementSystem.Repository;
using ClinicalManagementSystem.Service;
using validation;

namespace ClinicalManagementSystem
{
    public class DoctorDashboard
    {
        IDoctorRepository doctorRepository = null;
        IDoctorService doctorService = null;
        public DoctorDashboard()
        {
            //Call User Repository and User Service
            doctorRepository = new DoctorRepository();
            doctorService = new DoctorService(doctorRepository);

        }
        public void Doctor()
        {
            char choice = 'N';
            do
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine(" Welcome Doctor");

                    Console.WriteLine("Enter your choice \n");
                    Console.WriteLine("1.List Appointments ");
                   
                    Console.WriteLine("2.Medical Report");
                    Console.WriteLine("4.Exiting");

                    int Choice = Convert.ToInt32(Console.ReadLine());
                    switch (Choice)
                    {
                        case 1:
                            ListAppointment(); // Call the ListAppointment method
                            break;
                     
                        case 2:
                            MedicalReport();
                            break;
                        case 4:
                            CMSApp app = new CMSApp();
                            app.LoginAppAsync();
                            break;
                        case 5:
                            //Implement Add test
                            break;
                        case 6:
                            return; // Exiting the method
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    // Clear the input buffer
                    Console.ReadLine();
                }

                Console.WriteLine("Do you want to go to Doctor Dashboard?(Y/N)");
                string input = Console.ReadLine().Trim().ToUpper();
                choice = input.Length > 0 ? input[0] : 'N'; // Check if input is not empty before accessing the first character
            } while (choice == 'Y');
        }
        //Methods for ListAppointments
        public void ListAppointment()
        {
            do
            {
                Console.WriteLine("\nAppointment lists\n");
                doctorService.ListAppointmentService();
                Diagnosis();

                Console.WriteLine("\nDo you want to visit another appointment? (Y/N)");
                string response = Console.ReadLine();

                if (response.ToUpper() != "Y")
                {
                    break;
                }

            } while (true);


        }
        //Methods for SearchHistory
        public void Searchhistory()
        {
            Console.WriteLine("Patient History");
            Console.WriteLine("Enter patientname :");
            string Patientname = Console.ReadLine();
            new DoctorDashboard().doctorService.PatientSearchHistory(Patientname);
        }

        /*
        public void Diagnosis()
        {
            Console.WriteLine("\nDiagnosis Details\n");

            //appointmentid
            Console.Write("Token : ");
            int appointmentid = Convert.ToInt32(Console.ReadLine());

            //patientid
            string patientName = doctorService.Patientservice(appointmentid);

            //DoctorID
            int doctorid = doctorService.Doctorname(appointmentid);

            //symptoms
            Console.Write("Symptoms : ");
            string symptoms = Console.ReadLine();

            //Diagnosis details
            Console.Write("Diagnosis details : ");
            string diagnosisDetails = Console.ReadLine();

            // Medicines
            List<string> chosenMedicines = new List<string>();
            string medicineName = "";
            string dosage = "";
            string course = "";
            do
            {
                Console.WriteLine("\nChoose the Medicine:\n");
                Console.WriteLine("1. Paracetamol");
                Console.WriteLine("2. Ibuprofen");
                Console.WriteLine("3. Alclometasone");
                Console.WriteLine("4. Omeprazole");
                Console.WriteLine("5. Metformin\n");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            medicineName = "Paracetamol";
                            break;
                        case 2:
                            medicineName = "Ibuprofen";
                            break;
                        case 3:
                            medicineName = "Alclometasone";
                            break;
                        case 4:
                            medicineName = "Omeprazole";
                            break;
                        case 5:
                            medicineName = "Metformin";
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }

                    if (!chosenMedicines.Contains(medicineName))
                    {
                        chosenMedicines.Add(medicineName);
                    }
                    else
                    {
                        Console.WriteLine("This medicine has already been added.");
                    }

                    // Ask for dosage and course if a medicine was added
                    if (chosenMedicines.Count > 0)
                    {
                        Console.Write("\nNo of Dosage:\n ");
                        dosage = Console.ReadLine();

                        Console.Write("Course:\n ");
                        course = Console.ReadLine();
                    }

                    // Ask if more medicines need to be added
                    Console.WriteLine("Do you want to add more medicine? (yes/no)");
                    string addMoreMedicine = Console.ReadLine().ToLower();
                    if (addMoreMedicine != "yes")
                        break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            } while (true);

            Console.WriteLine("\nMedicines Chosen:\n");
            foreach (var med in chosenMedicines)
            {
                Console.WriteLine(med);
            }

            // Tests
            List<string> chosenTests = new List<string>();
            string testName = "";
            do
            {
                Console.WriteLine("\nChoose the Test:\n");
                Console.WriteLine("1. Blood Test");
                Console.WriteLine("2. Echo");
                Console.WriteLine("3. UltraSound");
                Console.WriteLine("4. MRI Test");
                Console.WriteLine("5. X-rays\n");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            testName = "Blood Test";
                            break;
                        case 2:
                            testName = "Echo";
                            break;
                        case 3:
                            testName = "UltraSound";
                            break;
                        case 4:
                            testName = "MRI Test";
                            break;
                        case 5:
                            testName = "X-rays";
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }

                    if (!chosenTests.Contains(testName))
                    {
                        chosenTests.Add(testName);
                    }
                    else
                    {
                        Console.WriteLine("This test has already been added.");
                    }

                    // Ask if more tests need to be added
                    Console.WriteLine("Do you want to add more tests? (yes/no)");
                    string addMoreTests = Console.ReadLine().ToLower();
                    if (addMoreTests != "yes")
                        break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            } while (true);

            Console.WriteLine("\nTests Chosen:\n");
            foreach (var test in chosenTests)
            {
                Console.WriteLine(test);
            }

            // Create Diagnosis object and save it using the service
            Diagnosis diagnosis = new Diagnosis(appointmentid, patientName, doctorid, symptoms, diagnosisDetails, medicineName, dosage, course, testName);
            doctorService.DiagnosisServive(diagnosis);
            Console.WriteLine("Diagnosis Added Successfully");
        }
        */

        /*
        public void Diagnosis()
        {
            Console.WriteLine("\nDiagnosis Details\n");

            // Appointment ID
            Console.Write("Token: ");
            int appointmentId = Convert.ToInt32(Console.ReadLine());

            // Patient ID
            string patientName = doctorService.Patientservice(appointmentId);

            // Doctor ID
            int doctorId = doctorService.Doctorname(appointmentId);

            // Symptoms
            Console.Write("Symptoms: ");
            string symptoms = Console.ReadLine();

            // Diagnosis Details
            Console.Write("Diagnosis details: ");
            string diagnosisDetails = Console.ReadLine();

            // Medicines
            List<string> chosenMedicines = new List<string>();
            string medicineName = "";
            string dosage = "";
            string course = "";
            do
            {
                Console.WriteLine("\nChoose the Medicine:\n");
                Console.WriteLine("1. Paracetamol");
                Console.WriteLine("2. Ibuprofen");
                Console.WriteLine("3. Alclometasone");
                Console.WriteLine("4. Omeprazole");
                Console.WriteLine("5. Metformin\n");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            medicineName = "Paracetamol";
                            break;
                        case 2:
                            medicineName = "Ibuprofen";
                            break;
                        case 3:
                            medicineName = "Alclometasone";
                            break;
                        case 4:
                            medicineName = "Omeprazole";
                            break;
                        case 5:
                            medicineName = "Metformin";
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            continue;
                    }

                    if (!chosenMedicines.Contains(medicineName))
                    {
                        chosenMedicines.Add(medicineName);
                    }
                    else
                    {
                        Console.WriteLine("This medicine has already been added.");
                    }

                    // Ask for dosage and course if a medicine was added
                    Console.Write("\nNumber of Dosages: ");
                    dosage = Console.ReadLine();

                    Console.Write("Course: ");
                    course = Console.ReadLine();

                    // Ask if more medicines need to be added
                    Console.WriteLine("Do you want to add more medicine? (yes/no)");
                    string addMoreMedicine = Console.ReadLine().ToLower();
                    if (addMoreMedicine != "yes")
                        break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            } while (true);

            Console.WriteLine("\nMedicines Chosen:\n");
            foreach (var med in chosenMedicines)
            {
                Console.WriteLine(med);
            }

            // Tests
            List<string> chosenTests = new List<string>();
            string testName = "";
            Console.WriteLine("Do you need to prescribe any tests? (yes/no)");
            string needTests = Console.ReadLine().ToLower();
            if (needTests == "yes")
            {
                do
                {
                    Console.WriteLine("\nChoose the Test:\n");
                    Console.WriteLine("1. Blood Test");
                    Console.WriteLine("2. Echo");
                    Console.WriteLine("3. UltraSound");
                    Console.WriteLine("4. MRI Test");
                    Console.WriteLine("5. X-rays\n");
                    try
                    {
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                testName = "Blood Test";
                                break;
                            case 2:
                                testName = "Echo";
                                break;
                            case 3:
                                testName = "UltraSound";
                                break;
                            case 4:
                                testName = "MRI Test";
                                break;
                            case 5:
                                testName = "X-rays";
                                break;
                            default:
                                Console.WriteLine("Invalid choice");
                                continue;
                        }

                        if (!chosenTests.Contains(testName))
                        {
                            chosenTests.Add(testName);
                        }
                        else
                        {
                            Console.WriteLine("This test has already been added.");
                        }

                        // Ask if more tests need to be added
                        Console.WriteLine("Do you want to add more tests? (yes/no)");
                        string addMoreTests = Console.ReadLine().ToLower();
                        if (addMoreTests != "yes")
                            break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                } while (true);

                Console.WriteLine("\nTests Chosen:\n");
                foreach (var test in chosenTests)
                {
                    Console.WriteLine(test);
                }
            }

            // Create Diagnosis object and save it using the service
            Diagnosis diagnosis = new Diagnosis(
                appointmentId, patientName, doctorId, symptoms, diagnosisDetails,
                chosenMedicines.Count > 0 ? chosenMedicines.Last() : string.Empty,
                dosage, course, chosenTests.Count > 0 ? chosenTests.Last() : string.Empty
            );
            //Diagnosis diagnosis = new Diagnosis(
            //appointmentId, patientName, doctorId, symptoms, diagnosisDetails,
            // chosenMedicines.Count > 0 ? chosenMedicines.Last() : string.Empty,
            //dosage, course, chosenTests.Count > 0 ? chosenTests.Last() : string.Empty
            //  );
            doctorService.DiagnosisServive(diagnosis);
            Console.WriteLine("Diagnosis Added Successfully");
        }
    */
        public void Diagnosis()
        {
            Console.WriteLine("\nDiagnosis Details\n");

            // Appointment ID
            Console.Write("Token: ");
            int appointmentId = Convert.ToInt32(Console.ReadLine());

            // Patient ID
            string patientName = doctorService.Patientservice(appointmentId);

            // Doctor ID
            int doctorId = doctorService.Doctorname(appointmentId);

            // Symptoms
            Console.Write("Symptoms: ");
            string symptoms = Console.ReadLine();

            // Diagnosis Details
            Console.Write("Diagnosis details: ");
            string diagnosisDetails = Console.ReadLine();

            // Medicines
            List<string> chosenMedicines = new List<string>();
            string medicineName = "";
            string dosage = "";
            string course = "";
            do
            {
                Console.WriteLine("\nChoose the Medicine:\n");
                Console.WriteLine("1. Paracetamol");
                Console.WriteLine("2. Ibuprofen");
                Console.WriteLine("3. Alclometasone");
                Console.WriteLine("4. Omeprazole");
                Console.WriteLine("5. Metformin\n");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            medicineName = "Paracetamol";
                            break;
                        case 2:
                            medicineName = "Ibuprofen";
                            break;
                        case 3:
                            medicineName = "Alclometasone";
                            break;
                        case 4:
                            medicineName = "Omeprazole";
                            break;
                        case 5:
                            medicineName = "Metformin";
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            continue;
                    }

                    if (!chosenMedicines.Contains(medicineName))
                    {
                        chosenMedicines.Add(medicineName);
                    }
                    else
                    {
                        Console.WriteLine("This medicine has already been added.");
                    }

                    // Ask for dosage and course if a medicine was added
                    Console.Write("\nNumber of Dosages: ");
                    dosage = Console.ReadLine();

                    Console.Write("Course: ");
                    course = Console.ReadLine();

                    // Ask if more medicines need to be added
                    Console.WriteLine("Do you want to add more medicine? (yes/no)");
                    string addMoreMedicine = Console.ReadLine().ToLower();
                    if (addMoreMedicine != "yes")
                        break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            } while (true);

            Console.WriteLine("\nMedicines Chosen:\n");
            foreach (var med in chosenMedicines)
            {
                Console.WriteLine(med);
            }

            // Tests
            List<string> chosenTests = new List<string>();
            string testName = "";
            Console.WriteLine("Do you need to prescribe any tests? (yes/no)");
            string needTests = Console.ReadLine().ToLower();
            if (needTests == "yes")
            {
                do
                {
                    Console.WriteLine("\nChoose the Test:\n");
                    Console.WriteLine("1. Blood Test");
                    Console.WriteLine("2. Echo");
                    Console.WriteLine("3. UltraSound");
                    Console.WriteLine("4. MRI Test");
                    Console.WriteLine("5. X-rays\n");
                    try
                    {
                        int choice = Convert.ToInt32(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                testName = "Blood Test";
                                break;
                            case 2:
                                testName = "Echo";
                                break;
                            case 3:
                                testName = "UltraSound";
                                break;
                            case 4:
                                testName = "MRI Test";
                                break;
                            case 5:
                                testName = "X-rays";
                                break;
                            default:
                                Console.WriteLine("Invalid choice");
                                continue;
                        }

                        if (!chosenTests.Contains(testName))
                        {
                            chosenTests.Add(testName);
                        }
                        else
                        {
                            Console.WriteLine("This test has already been added.");
                        }

                        // Ask if more tests need to be added
                        Console.WriteLine("Do you want to add more tests? (yes/no)");
                        string addMoreTests = Console.ReadLine().ToLower();
                        if (addMoreTests != "yes")
                            break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                } while (true);

                Console.WriteLine("\nTests Chosen:\n");
                foreach (var test in chosenTests)
                {
                    Console.WriteLine(test);
                }
            }

            // Create Diagnosis object and save it using the service
            Diagnosis diagnosis = new Diagnosis(
                appointmentId, patientName, doctorId, symptoms, diagnosisDetails,
                chosenMedicines.Count > 0 ? string.Join(", ", chosenMedicines) : string.Empty,  // Join medicines into a single string
                dosage, course, chosenTests.Count > 0 ? string.Join(", ", chosenTests) : string.Empty  // Join tests into a single string
            );

            doctorService.DiagnosisServive(diagnosis);
            Console.WriteLine("Diagnosis Added Successfully");
        }

        //Methods for MedicalReport
        public void MedicalReport()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                             MEDICAL REPORT                                        ");
            Console.WriteLine(" -------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Patient Details  ");
            Console.WriteLine("Patient Name : ramu");
            Console.WriteLine("Age          : 20");
            Console.WriteLine("Gender       : Female");
            Console.WriteLine("Doctor Name  : Dhanusha");
            Console.WriteLine("Diagnosis    : heart issue");
            Console.WriteLine("PatientId    : 1");
            Console.WriteLine("AppointmentDate : 27/08/2024");
            Console.WriteLine("Sample Received Date : 27/08/2024");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                                        LABORATORY REPORT                                        ");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Blood Test");
            Console.WriteLine("Blood Group : b+");
            Console.WriteLine("whiteBloodCells = 8300; // in cells/mcL");
            Console.WriteLine("redBloodCells = 6.2; // in million cells/mcL");
            Console.WriteLine("hemoglobin = 18.3; // in g/dL");
            Console.WriteLine("platelets = 450000; // in platelets/mcL");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
        }

    }
}