using SBLibrary.Data.DAO;
using SBLibrary.Data.IDAO;
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
    public class AdminService : IAdminService
    {
        private IAdminDAO adminDAO;
        public AdminService()
        {
            adminDAO = new AdminDAO();
        }

        public void AdminDelUser(int id)
        {
            using (var context = new SBLibraryContext())
            {
                adminDAO.AdminDelUser(id, context);
            }
        }

        public User AdminGetUser(int id)
        {
            using (var context = new SBLibraryContext())
            {
                return adminDAO.AdminGetUser(id, context);
            }
            
        }

        public IEnumerable<User> AdminGetUsers()
        {
            using (var context = new SBLibraryContext())
            {
                return adminDAO.AdminGetUsers();
            }
        }
    }
}
