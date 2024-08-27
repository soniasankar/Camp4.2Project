using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagementSystem.Model
{
    public class Role
    {
        //fields
        public int Roleid { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }


        //constructor
        public Role(int roleid, string roleName, bool IsActive)
        {
            Roleid = roleid;
            RoleName = roleName;
            IsActive = IsActive;
        }
    }
}
