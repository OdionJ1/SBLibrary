using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.Models.Domain
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public virtual User User { get; set; }
        public string Title { get; set; }
        public System.DateTime Date { get; set; }
        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
    }
}
