using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.Models.Domain
{
    public class Upload
    {
        public int UploadID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}
