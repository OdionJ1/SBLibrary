using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.Models.Domain
{
    public class ForgotPassword
    {
        [Required]
         [Key]
        public string Username { get; set; }

        [Display(Name = "Username or your Emailid")]
        public string Emailid { get; set; }

        public virtual User User { get; set; }

        [Required(ErrorMessage = "New password required", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "New password and confirm password does not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string ResetCode { get; set; }
    }
}
