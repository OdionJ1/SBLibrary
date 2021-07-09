using SBLibrary.Data.Models.Domain;
using SBLibrary.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Service.Service
{
    public class LoginService
    {
        IUserService userService;

        public LoginService()
        {
            userService = new UserService();
        }
        public bool UserAuthenticated(Login loginData)
        {
            User UserData = userService.GetUser(loginData.Email);
            return UserData.Password == loginData.Password;
            
        }
    }
}
