using SBLibrary.Data.Models.Domain;
using SBLibrary.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.IDAO
{
    public interface IAdminDAO
    {
        IEnumerable<User> AdminGetUsers();
        void AdminDelUser(int id, SBLibraryContext context);

        User AdminGetUser(int id, SBLibraryContext context);
    }
}
