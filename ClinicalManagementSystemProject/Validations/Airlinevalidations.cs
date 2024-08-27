using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validations
{
    public class Airlinevalidations
    {
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
        // Validation methods for date and time formats
        
                    // Validate departureDate and departureTime
                    

   
    }
}
