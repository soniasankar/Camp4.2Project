using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicalManagementSystem.Repository;

namespace ClinicalManagementSystem.Service
{
    public class UsersService:IUsersService
    {
        //Field
        private IUsersRepository _userRepository;
        public UsersService(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }
        //for applying buisness rule call
        public int Authenticateuser(string username, string password)
        {
            //add validation business logic here
            //add validation with bll
            return _userRepository.AuthenticateUser(username, password);   
        }
    }
}
