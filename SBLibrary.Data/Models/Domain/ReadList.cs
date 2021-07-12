using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.Models.Domain
{
    public class ReadList
    {
        [Key]
        public int ReadListID { get; set; }

        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
    }
}
