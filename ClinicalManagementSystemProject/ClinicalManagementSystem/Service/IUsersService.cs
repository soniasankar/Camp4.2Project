using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagementSystem.Service
{
    public interface IUsersService
    {
        //Abstract Methods
        int Authenticateuser(string username, string password);
    }
}
