using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.Models.Domain
{
    public class ShareBook
    {

        [Key]
        [Column(Order = 0)]
        public int BookID { get; set; }


        [Key]
        [Column(Order = 1)]
        public int UserID { get; set; }


        public string EmailID { get; set; }

    }
}
