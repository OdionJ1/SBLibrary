using Newtonsoft.Json;
using SBLibrary.Data.DAO;
using SBLibrary.Data.IDAO;
using SBLibrary.Data.Models.Domain;
using SBLibrary.Data.Models.Repository;
using SBLibrary.Service.IService;
using SBLibrary.Service.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Service.Service
{
    public class BookService : IBookService
    {
        private IBookDAO bookDAO;
        private ICategoryDAO categoryDAO;
        private IAuthorDAO authorDAO;
        private IUserDAO userDAO;

        public BookService()
        {
            bookDAO = new BookDAO();
            categoryDAO = new CategoryDAO();
            authorDAO = new AuthorDAO();
            userDAO = new UserDAO();
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

        //Check if the book is already on the list
        public static bool exist2(int bookId, int userId)
        {
            using (var context = new SBLibraryContext())
            {
                var book = context.ReadLists.ToList().Find(y => y.Book.BookID == bookId && y.User.UserID == userId);
                if (book != null)
                {
                    return true;
                }
                return false;
            }
        }

        public void AddToReadList(int bookId, int userId)
        {
            if (!exist2(bookId, userId))
            {
                using (var context = new SBLibraryContext())
                {
                    bookDAO.AddToReadList(bookId, userId, context);
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

        public void RemoveFromFavList(int bookId, int userId)
        {
            using (var context = new SBLibraryContext())
            {
                bookDAO.RemoveFromFavList(bookId, userId, context);
            }
        }

        public void RemoveFromReadList(int bookId, int userId)
        {
            using (var context = new SBLibraryContext())
            {
                bookDAO.RemoveFromReadList(bookId, userId, context);
            }
        }

        public IList<Book> GetReadList(int userId)
        {
            using (var context = new SBLibraryContext())
            {
                return bookDAO.GetReadList(userId, context);
            }
        }

        //impliment get book interface for details
        public Book GetBook(int id)
        {
            var context = new SBLibraryContext();
            var book = bookDAO.GetBook(id, context);
            return book;
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

        public IList<Book> Search(string searchBy, int userId, string search)
        {
            using (var context = new SBLibraryContext())
            {
                return bookDAO.Search(searchBy, userId, search, context);
            }
        }

        public int AddBook(UploadBook uploadBook, int userId)
        {


            using (var context = new SBLibraryContext())
            {
                return bookDAO.AddBook(uploadBook, userId, context);
            }

        }

        public void ShareBook(ShareBook shareBook)
        {
            using (var context = new SBLibraryContext())
            {
                bookDAO.ShareBook(shareBook, context);
            }

        }

        public List<Item> GetGoogleBooks(string searchBookName)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://www.googleapis.com/books/v1/volumes?q="+ searchBookName),
                //Headers =
                //{
                //    { "x-rapidapi-key", "06d4f33d43msh7d29cd20fe93f99p133ba0jsnfd378b3d6c84" },
                //    { "x-rapidapi-host", "google-books.p.rapidapi.com" },
                //},
            };
            using (var response =  client.SendAsync(request))
            {
                //response.EnsureSuccessStatusCode();
                var body = response.Result.Content.ReadAsStringAsync();

                Root googleBooks = new Root();
                try
                {
                    googleBooks = JsonConvert.DeserializeObject<Root>(body.Result);
                    return googleBooks.items;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            return null;
        }
    }
}
