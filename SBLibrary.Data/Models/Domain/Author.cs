using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.Models.Domain
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Display(Name = "Author Name")]
        [Required(ErrorMessage = "Enter the author name")]
        public string AuthorName { get; set; }

        // Foreign key to User
        public virtual User User { get; set; }
    }
}
