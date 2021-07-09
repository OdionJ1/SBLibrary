using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.Models.Domain
{
    public class Category
    {
        [Key]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        // Foreign key to User
        public virtual User User { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
