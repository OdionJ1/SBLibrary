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
        public int CategoryId { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Enter the Category name")]
        public string CategoryName { get; set; }
        // Foreign key to User
        public virtual User User { get; set; }
    }
}
