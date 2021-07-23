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
        public string CurrentPassword { get; set; }


        [Required, DataType(DataType.Password), Display(Name = "New Password")]
        public string NewPassword { get; set; }


        [Required, DataType(DataType.Password), Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "Confirm Password and New Password does not match")]
        public string ConfirmPassword { get; set; }


        public virtual User User { get; set; }

        //public System.DateTime ResetPasswordTime { get; set; }
    }
}
