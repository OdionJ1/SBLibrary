using SBLibrary.Data.Models.Domain;
using SBLibrary.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Service.IService
{
    public interface IBookService
    {
        IList<Book> GetBooks();

        //book service interface to get books
        Book GetBook(int id);
        IList<Book> GetBooks(int id);

        //edit book
        Book EditBook(int id);

        int EditBook(Book book);

        //delete
        //Book DelBook(int id);
        void DelBook(int id);

        IList<Book> Search(string searchBy, string search);

        //void AddMusic(UploadBook uploadBook, string UserID);
    }
}
