using SBLibrary.InServices.IService;
using SBLibraryWebApi;
using SBLibraryWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.InServices.Service
{
    public class GoogleBookService : IGoogleBookService
    {
        private GoogleBooks googleBooks;

        public GoogleBookService()
        {
            googleBooks = new GoogleBooks();
        }

        public IList<Item> GetGoogleBooks(string searchBookName)
        {
            return googleBooks.GetGoogleBooks(searchBookName);
        }
    }
}
