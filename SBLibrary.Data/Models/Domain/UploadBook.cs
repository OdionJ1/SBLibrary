using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.Models.Domain
{
    public class UploadBook
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Enter the Title of the Book")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must selected an author. Add new author if there are none")]
        public string Author { get; set; }

        [Required(ErrorMessage = "You must selected a category. Add new category if there are none")]
        public string Category { get; set; }

    }
}
