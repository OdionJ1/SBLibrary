using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.Models.Domain
{
    public class Favorite
    {
        [Key]
        public int FavoriteListID { get; set; }

        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
    }
}
