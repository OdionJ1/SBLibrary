using SBLibrary.Data.Models.Domain;
using SBLibrary.Data.Models.Repository;
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
        public User UserAuthenticated(Login loginData)
        {
            
            using(SBLibraryContext db = new SBLibraryContext())
            {
                var user = db.Users.Where(a => a.Email == loginData.Email && a.Password == loginData.Password).FirstOrDefault();
                return user;
            }
            //User UserData = userService.GetUser(loginData.Email);
            //return UserData.Password == loginData.Password;
            
        }
    }
}
