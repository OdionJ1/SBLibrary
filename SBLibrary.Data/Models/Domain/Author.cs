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
        [Required(ErrorMessage = "Enter the Author name")]
        public string AuthorName { get; set; }
        // Foreign key to User
        public virtual User User { get; set; }

    }
}
