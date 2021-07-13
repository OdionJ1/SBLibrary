using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Service.Models
{
    public class UploadBook
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Enter the Title of the Book")]
        public string Name { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }

    }
}
