using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.Models.Domain
{
    public class ReadList
    {
        public int ReadListID { get; set; }
        public ICollection<Book> Books { get; set; }
        public virtual User User { get; set; }
    }
}
