using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace validation
{
    /*
    public class validations
    {
        //user Name should not be empty
        //user Name should contain only letters,numbers,underscores,and


        public static bool IsValidUsername(string userName)
        {
            return !string.IsNullOrEmpty(userName) &&
           Regex.IsMatch(userName, @"^[a-zA-Z\s]{3,15}$");
        }


        //password should have atleast 4 character
        //including at least one uppercase letter ,one lowercase letter,
        //one digit and one special character
        public static bool IsvalidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) &&
                Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\da-zA-Z]).{4,}$");
        }
        //replace alphabets with *symbol for password
        public static string ReadPassword()
        {
            string password = "";
           
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                //1.each keystroke from the user ,replaces it with an asterisk (*)
                //and adds it to the password string untill the user presses the Enter key
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                //2.allows the user to backspace and correct mistakes
                //while typing the password
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, (password.Length - 1));
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return password;
        }
        //validation for dob
       
        public static bool IsValidDOB(string dob)
        {
            DateTime parsedDate;
            string format = "dd/MM/yyyy"; // Specify the format you expect
            if (DateTime.TryParseExact(dob, format, null, System.Globalization.DateTimeStyles.None, out parsedDate))
            {
                // Check if the date is in the future or today
                if (parsedDate >= DateTime.Today)
                {
                    Console.WriteLine("Date of birth cannot be today or in the future.");
                    return false;
                }
                // Check if the user is at least 18 years old
                DateTime minDate = DateTime.Today.AddYears(-18);
                if (parsedDate > minDate)
                {
                    // Console.WriteLine("User must be at least 18 years old.");
                    return false;
                }
                return true;
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter the date in dd/MM/yyyy format.");
                return false;
            }
        }
        //address
        public static bool IsValidAddress(string address)
        {
            return !string.IsNullOrEmpty(address) &&
               Regex.IsMatch(address, @"^[a-zA-Z ]{5,15}(?: [a-zA-Z]+)*$");
        }
        //Bloodgroup
        public static bool isValidBloodGroup(string bloodGroup)
        {
            // Define regular expression pattern to validate blood group
            string pattern = @"^(A|B|AB|O)[\+-]$";
            return Regex.IsMatch(bloodGroup, pattern);
        }
        //gender
        public static bool isValidGender(string gender)
        {
            // Assuming gender can be either "Male", "Female", "Other", "M", "F", or "O"
            return gender.Equals("Male", StringComparison.OrdinalIgnoreCase) ||
                   gender.Equals("Female", StringComparison.OrdinalIgnoreCase) ||
                   gender.Equals("Other", StringComparison.OrdinalIgnoreCase) ||
                   gender.Equals("M", StringComparison.OrdinalIgnoreCase) ||
                   gender.Equals("F", StringComparison.OrdinalIgnoreCase) ||
                   gender.Equals("O", StringComparison.OrdinalIgnoreCase);
        }
        //email
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        //phonenumber
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Assuming phone number is in a standard format
            return !string.IsNullOrWhiteSpace(phoneNumber) && Regex.IsMatch(phoneNumber, @"^([6789]\d{9})$");

        }
        /*public static bool IsvalidUsername(string userName)
        {
            return !string.IsNullOrEmpty(userName) &&
              Regex.IsMatch(userName, @"^[a-zA-Z]{6,}$");
        }*/
    //validations for appointment
    /*
    public static bool IsValidDoctorID(int doctorID)
    {
        // DoctorID should always be greater than 0
        return doctorID > 0;
    }
    public static bool IsValidReasonForAppointment(string reasonForAppointment)
    {
        // Ensure reasonForAppointment is not null or empty
        return !string.IsNullOrEmpty(reasonForAppointment);
    }
    public static bool IsValidAppointmentTime(string appointmentTime)
    {
        // Define pattern for valid time format (HH:mmAM/PM)
        string pattern = @"^(0[1-9]|1[0-2]):[0-5][0-9](AM|PM)$";

        // Check if the input matches the pattern
        return Regex.IsMatch(appointmentTime, pattern);
    }
    public static bool IsValidAppointmentDate(string appointmentDate)
    {
        // Define pattern for valid date format (YYYY-MM-DD)
        string pattern = @"^\d{4}-\d{2}-\d{2}$";

        // Check if the input matches the pattern
        return Regex.IsMatch(appointmentDate, pattern);
    }
    public static bool IsValidRegistrationFees(string registrationFees)
    {
        // Check if the input is not null or empty
        if (string.IsNullOrEmpty(registrationFees))
            return false;

        // Try parsing the input as a decimal number
        if (!decimal.TryParse(registrationFees, out decimal fees))
            return false;

        // Check if the parsed value is non-negative
        if (fees < 0)
            return false;

        // Optionally, you can add more specific validation rules here, such as maximum value, etc.

        // If all validation checks pass, return true
        return true;
    }




*/
    public class validations
    {
        //user Name should not be empty
        //user Name should contain only letters,numbers,underscores,and


        public static bool IsValidUsername(string userName)
        {
            return !string.IsNullOrEmpty(userName) &&
           Regex.IsMatch(userName, @"^[a-zA-Z\s]{3,15}$");
        }


        //password should have atleast 4 character
        //including at least one uppercase letter ,one lowercase letter,
        //one digit and one special character
        public static bool IsvalidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) &&
                Regex.IsMatch(password, @"^(?=.[a-z])(?=.[A-Z])(?=.\d)(?=.[\da-zA-Z]).{4,}$");
        }
        //replace alphabets with *symbol for password
        public static string ReadPassword()
        {
            string password = "";

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                //1.each keystroke from the user ,replaces it with an asterisk (*)
                //and adds it to the password string untill the user presses the Enter key
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                //2.allows the user to backspace and correct mistakes
                //while typing the password
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, (password.Length - 1));
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return password;
        }
        //validation for dob
        public static bool IsValidDOB(string dob)
        {
            DateTime parsedDate;
            if (DateTime.TryParse(dob, out parsedDate))
            {
                // Check if the date is in the future or today
                if (parsedDate >= DateTime.Today)
                {
                    Console.WriteLine("Date of birth cannot be today or in the future.");
                    return false;
                }
                // Check if the user is at least 18 years old
                DateTime minDate = DateTime.Today.AddYears(-18);
                if (parsedDate > minDate)
                {
                    //Console.WriteLine("User must be at.");
                    return false;
                }
                return true;
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter the date in dd/mm/yyyy format.");
                return false;
            }
        }


        //address
        public static bool IsValidAddress(string address)
        {
            return !string.IsNullOrEmpty(address) &&
               Regex.IsMatch(address, @"^[a-zA-Z ]{5,15}(?: [a-zA-Z]+)*$");
        }
        //Bloodgroup
        public static bool isValidBloodGroup(string bloodGroup)
        {
            // Define regular expression pattern to validate blood group
            string pattern = @"^(A|B|AB|O)[\+-]$";
            return Regex.IsMatch(bloodGroup, pattern);
        }
        //gender
        public static bool isValidGender(string gender)
        {
            // Assuming gender can be either "Male", "Female", "Other", "M", "F", or "O"
            return gender.Equals("Male", StringComparison.OrdinalIgnoreCase) ||
                   gender.Equals("Female", StringComparison.OrdinalIgnoreCase) ||
                   gender.Equals("Other", StringComparison.OrdinalIgnoreCase) ||
                   gender.Equals("M", StringComparison.OrdinalIgnoreCase) ||
                   gender.Equals("F", StringComparison.OrdinalIgnoreCase) ||
                   gender.Equals("O", StringComparison.OrdinalIgnoreCase);
        }
        //email
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        //phonenumber
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Assuming phone number is in a standard format
            return !string.IsNullOrWhiteSpace(phoneNumber) && Regex.IsMatch(phoneNumber, @"^([6789]\d{9})$");

        }
        /*public static bool IsvalidUsername(string userName)
        {
            return !string.IsNullOrEmpty(userName) &&
              Regex.IsMatch(userName, @"^[a-zA-Z]{6,}$");
        }*/
        //validations for appointment

        public static bool IsValidDoctorID(int doctorID)
        {
            // DoctorID should always be greater than 0
            return doctorID > 0;
        }
        public static bool IsValidReasonForAppointment(string reasonForAppointment)
        {
            // Ensure reasonForAppointment is not null or empty
            return !string.IsNullOrEmpty(reasonForAppointment);
        }
        public static bool IsValidAppointmentTime(string appointmentTime)
        {
            // Define pattern for valid time format (HH:mmAM/PM)
            string pattern = @"^(0[1-9]|1[0-2]):[0-5][0-9](AM|PM)$";

            // Check if the input matches the pattern
            return Regex.IsMatch(appointmentTime, pattern);
        }
        public static bool IsValidAppointmentDate(string appointmentDate)
        {
            // Define pattern for valid date format (YYYY-MM-DD)
            string pattern = @"^\d{4}-\d{2}-\d{2}$";

            // Check if the input matches the pattern
            return Regex.IsMatch(appointmentDate, pattern);
        }
        public static bool IsValidRegistrationFees(string registrationFees)
        {
            // Check if the input is not null or empty
            if (string.IsNullOrEmpty(registrationFees))
                return false;

            // Try parsing the input as a decimal number
            if (!decimal.TryParse(registrationFees, out decimal fees))
                return false;

            // Check if the parsed value is non-negative
            if (fees < 0)
                return false;

            // Optionally, you can add more specific validation rules here, such as maximum value, etc.

            // If all validation checks pass, return true
            return true;
        }














    }
}









