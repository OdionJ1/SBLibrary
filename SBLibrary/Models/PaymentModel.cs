using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SBLibrary.Models
{
    public class PaymentModel
    {
        [Key] //This is required to create the PayForBook view
        public int PaymentId { get; set; }

        //Add in authentication
        //Only letters
        [Display(Name = "Card Holder Name")]
        [RegularExpression("^[a-zA-Z ]+$")]
        [Required(ErrorMessage = "Enter Card Holder Name")]
        public string CardHolderName { get; set; }

        //Only numbers, 16 digits max
        [Display(Name = "Card Number")]
        [RegularExpression("^[0-9 ]+$")]
        [MinLength(16)]
        [Required(ErrorMessage = "Enter 16 digit Card Number")]
        public string CardNumber { get; set; }

        //Date month/year only 
        [Display(Name = "Expiry Date")]
        //[DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM/yyyy}")]
        [Required(ErrorMessage = "Enter Expiry Date of Card. Month and year(MM/YY)")]
        public DateTime ExpiryDate { get; set; }

        //Only numbers, 3 digits max
        [Display(Name = "CVV")]
        //[RegularExpression("[^0-9+$]")]
        [MinLength(3)]
        [MaxLength(3)]
        [Required(ErrorMessage = "Enter 3 digit CVV Number")]
        public string CvvNumber { get; set; }
    }
}