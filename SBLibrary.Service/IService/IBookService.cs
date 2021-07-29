using SBLibrary.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Service.IService
{
    public interface IBookService
    {
        IList<Book> GetFavouriteBooks(int userId);

        IList<Book> GetReadList(int userId);
        IList<Book> GetBooks();

        //book service interface to get books
        Book GetBook(int id);
        IList<Book> GetBooks(int id);

        //edit book
        Book EditBook(int id);

        int EditBook(Book book);

        void AddToFavList(int bookId, int userId);
        void RemoveFromFavList(int bookId, int userId);
        void RemoveFromReadList(int bookId, int userId);
        void AddToReadList(int bookId, int userId);

        //delete
        //Book DelBook(int id);
        void DelBook(int id);

        IList<Book> Search(string searchBy, int userId, string search);

        int AddBook(UploadBook uploadBook, int UserId);

        void ShareBook(ShareBook shareBook);

        void AddToBookList(int userId, string title, string author, string category, string link);
    }
}
