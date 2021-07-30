using SBLibrary.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Service.IService
{
    public interface IAdminService
    {
        IEnumerable<User> AdminGetUsers();

        User AdminGetUser(int id);

        void AdminDelUser(int id);
    }
}
