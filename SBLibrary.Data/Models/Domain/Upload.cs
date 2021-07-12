using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.Models.Domain
{
    public class Upload
    {
        [Key]
        public int UploadID { get; set; }
        public string Name { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }
    }
}
