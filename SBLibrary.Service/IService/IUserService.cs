using SBLibrary.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Service.IService
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        void CreateUser(User user);

        User GetUser(string email);
        void ChangePassword(ChangePassword resetmodel);

        void ForgotPassword(string EmailID);
    }
}
