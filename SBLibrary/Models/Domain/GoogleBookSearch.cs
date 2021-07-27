using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SBLibrary.Models.Domain
{
    public class GoogleBookSearch
    {
        [Display(Name = "Search Book Title")]
        public string SearchBookName { get; set; }

        
    }
}