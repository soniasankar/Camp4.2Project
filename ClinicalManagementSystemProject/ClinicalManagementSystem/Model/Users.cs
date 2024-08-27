using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagementSystem.Model
{
    public class Users
    {
        //fields
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int Roleid { get; set; }

        //constructor
        public Users(string userName, string password)
        {

            UserName = userName;
            Password = password;

        }
    }
}
