using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.Models.Domain
{
    public class Author
    {
       [Key]
       [Display(Name = "Author Name")]
        public string AuthorName { get; set; }
        // Foreign key to User
        public virtual User User { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }
}
