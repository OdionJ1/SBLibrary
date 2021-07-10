using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.Models.Domain
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        //[Display(Name = "First Name")]
        //[Required(ErrorMessage = "Enter your first name")]
        public string FirstName { get; set; }

        //[Display(Name = "Last Name")]
        //[Required(ErrorMessage = "Enter your Last name")]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "Enter password")]
        //[DataType(DataType.Password)]
        //[StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        //[RegularExpression(@"^([a-zA-Z0-9@*#]{8,15})$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase      Alphabet, 1 Number and 1 Special Character")]
        public string Password { get; set; }

        //[Display(Name = "Confirm Password")]
        //[Required(ErrorMessage = "Enter confirm password")]
        //[Compare("Password", ErrorMessage = "Confirm password doesn't match!")]
        //[DataType(DataType.Password)]
        public string Confirmpwd { get; set; }

        //[Required]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        public string Email { get; set; }

        //[Required]
        //[DataType(DataType.PhoneNumber)]
        //[Display(Name = "Phone Number")]
        public string Mobile { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<ReadList> ReadLists { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        //public IList<Book> Book { get; } = new List<Book>();
    }
}
