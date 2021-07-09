using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.Models.Domain
{
    public class Favorite
    {
        public int FavoriteID { get; set; }
        public ICollection<Book> Books { get; set; }
        public virtual User User { get; set; }
    }
}
