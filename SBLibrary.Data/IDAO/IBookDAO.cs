using SBLibrary.Data.Models.Domain;
using SBLibrary.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.IDAO
{
    public interface IBookDAO
    {
        IList<Book> GetBooks(SBLibraryContext context);
        IList<Book> GetFavouriteBooks(int userId, SBLibraryContext context);

        IList<Book> GetReadList(int userId, SBLibraryContext context);
        Book GetBook(int id, SBLibraryContext context);
        IList<Book> GetBooks(int id, SBLibraryContext context);

        Book EditBook(int id, SBLibraryContext context);
        int EditBook(Book book);

        void AddToFavList(int bookId, int userId, SBLibraryContext context);

        void RemoveFromFavList(int bookId, int userId, SBLibraryContext context);

        void RemoveFromReadList(int bookId, int userId, SBLibraryContext context);

        void AddToReadList(int bookId, int userId, SBLibraryContext context);

        //Delete
        //Book DelBook(int id, SBLibraryContext context);
        void DelBook(int id, SBLibraryContext context);

        IList<Book> Search(string searchBy, string search, SBLibraryContext context);

        int AddBook(UploadBook book, int userId, SBLibraryContext context);

        void ShareBook(ShareBook shareBook, SBLibraryContext context);

    }
}
