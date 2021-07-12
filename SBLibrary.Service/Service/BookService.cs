using SBLibrary.Data.DAO;
using SBLibrary.Data.IDAO;
using SBLibrary.Data.Models.Domain;
using SBLibrary.Data.Models.Repository;
using SBLibrary.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Service.Service
{
    public class BookService : IBookService
    {
        private IBookDAO bookDAO;
        public BookService()
        {
            bookDAO = new BookDAO();
        }

        //Check if the book is already on the list
        public static bool exist(int bookId, int userId)
        {
            using (var context = new SBLibraryContext())
            {
                var favBook = context.Favorites.ToList().Find(y => y.Book.BookID == bookId && y.User.UserID == userId);
                if (favBook != null)
                {
                    return true;
                }
                return false;
            }
        }

        public void AddToFavList(int bookId, int userId)
        {
            if (!exist(bookId, userId))
            {
                using (var context = new SBLibraryContext())
                {
                    bookDAO.AddToFavList(bookId, userId, context);
                }
            }
        }
        public IList<Book> GetFavouriteBooks(int userId)
        {
            using (var context = new SBLibraryContext())
            {
                return bookDAO.GetFavouriteBooks(userId, context);
            }
        }

        //impliment get book interface for details
        public Book GetBook(int id)
        {
            using (var context = new SBLibraryContext())
            {
                return bookDAO.GetBook(id, context);
            }
        }

        public IList<Book> GetBooks()
        {
            using (var context = new SBLibraryContext())
            {
                return bookDAO.GetBooks(context);
            }
        }

        //impliment get books interface for details
        public IList<Book> GetBooks(int id)
        {
            using (var context = new SBLibraryContext())
            {
                return bookDAO.GetBooks(id, context);
            }
        }
        //edit book

        public Book EditBook(int id)
        {
            using (var context = new SBLibraryContext())
            {

                return bookDAO.EditBook(id, context);
            }
        }

        public int EditBook(Book book)
        {
            return bookDAO.EditBook(book);
        }

        public void DelBook(int id)
        {
            using (var context = new SBLibraryContext())
            {
                bookDAO.DelBook(id, context);

            }
        }

        public IList<Book> Search(string searchBy, string search)
        {
            using (var context = new SBLibraryContext())
            {
                return bookDAO.Search(searchBy, search, context);
            }
        }
    }
}
