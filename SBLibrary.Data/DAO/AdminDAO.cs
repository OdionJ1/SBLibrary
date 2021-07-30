using SBLibrary.Data.IDAO;
using SBLibrary.Data.Models.Domain;
using SBLibrary.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.DAO
{
    public class AdminDAO : IAdminDAO
    {
        private SBLibraryContext context;
        public AdminDAO()
        {
            context = new SBLibraryContext();
        }
        public void AdminDelUser(int id, SBLibraryContext context)
        {
            try
            {
                User user = context.Users.Find(id);
                context.Users.Remove(user);
                context.SaveChanges();

            }
            catch
            {
                throw;
            }
        }

        public User AdminGetUser(int id, SBLibraryContext context)
        {
            return context.Users.ToList().Find(x => x.UserID == id);
        }

        public IEnumerable<User> AdminGetUsers()
        {
            return context.Users.ToList();
        }
    }
}
