using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.Models.Domain
{
    public class UserRole
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        //one to many relationship
        public List<User> Users { get; set; }
    }
}
