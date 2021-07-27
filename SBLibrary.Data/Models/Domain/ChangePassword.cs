using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.Models.Domain
{
    public class ChangePassword
    {
        [Key]

        [Display(Name = "User Id")]
        public int UserId { get; set; }

        [Display(Name = "Email Id")]
        public string EmailID { get; set; }


        
        [Required, DataType(DataType.Password), Display(Name = "Current Password")]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        [RegularExpression(@"^([a-zA-Z0-9@*#]{8,15})$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase      Alphabet, 1 Number and 1 Special Character")]

        public string CurrentPassword { get; set; }


        [Required, DataType(DataType.Password), Display(Name = "New Password")]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        [RegularExpression(@"^([a-zA-Z0-9@*#]{8,15})$", ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase      Alphabet, 1 Number and 1 Special Character")]

        public string NewPassword { get; set; }


        [Required, DataType(DataType.Password), Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "Confirm Password and New Password does not match")]
        public string ConfirmPassword { get; set; }


        public virtual User User { get; set; }

        //public System.DateTime ResetPasswordTime { get; set; }
    }
}
