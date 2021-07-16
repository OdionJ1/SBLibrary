using SBLibrary.Data.DAO;
using SBLibrary.Data.IDAO;
using SBLibrary.Data.Models.Domain;
using SBLibrary.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Service.Service
{
    public class UserService : IUserService
    {
        private IUserDAO userDAO;
        public UserService()
        {
            userDAO = new UserDAO();
        }

        public void CreateUser(User user)
        {
            
            userDAO.CreateUsers(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return userDAO.GetUsers();
        }

        public User GetUser(string email)
        {
            return userDAO.GetUser(email);
        }
        public void ResetPassword(ResetPassword resetmodel)
        {
            userDAO.ResetPassword(resetmodel);
        }
    }
}
