using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagementSystem.Repository
{
    public interface IUsersRepository
    {
        //Abstract Methods
        int AuthenticateUser(string username, string password);
    }
}
