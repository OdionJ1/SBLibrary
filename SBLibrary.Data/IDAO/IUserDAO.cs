using SBLibrary.Data.Models.Domain;
using SBLibrary.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.IDAO
{
    public interface IUserDAO
    {
        IEnumerable<User> GetUsers();

        void CreateUsers(User user);

        User GetUser(string email);
        void ResetPassword(ResetPassword resetmodel);
    }
}
