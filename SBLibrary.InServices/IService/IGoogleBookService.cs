using SBLibraryWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.InServices.IService
{
    public interface IGoogleBookService
    {
        IList<Item> GetGoogleBooks(string searchBookName);
    }
}
