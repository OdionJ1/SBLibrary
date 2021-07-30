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

        //Check if the book is already on the list
        public static bool exist3(string title, int userId)
        {
            using (var context = new SBLibraryContext())
            {
                var book = context.Books.ToList().Find(y => y.Title == title && y.User.UserID == userId);
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

        public void AddToBookList(int userId, string title, string author, string category, string link)
        {
            using (var context = new SBLibraryContext())
            {
                //Add google book category to category table
                Category category1 = new Category()
                {
                    CategoryName = category,
                };
                categoryDAO.AddCategory(userId, category1, context);
                context.SaveChanges();

                //Add google book author to author table
                Author author1 = new Author()
                {
                    AuthorName = author
                };
                authorDAO.AddAuthor(userId, author1, context);
                context.SaveChanges();

                Category category2 = context.Categories.ToList().Find(y => y.CategoryName == category && y.User.UserID == userId);
                Author author2 = context.Authors.ToList().Find(y => y.AuthorName == author && y.User.UserID == userId);
                User user = context.Users.ToList().Find(y => y.UserID == userId);

                Book newBook = new Book()
                {
                    Title = title,
                    Author = author2,
                    Category = category2,
                    User = user,
                    Date = DateTime.Now,
                    GoogleBook = true,
                    DownloadLink = link
                };

                context.Books.Add(newBook);

                //UploadBook newBook = new UploadBook()
                //{
                //    Name = title,
                //    Author = author2.AuthorId.ToString(),
                //    Category = category2.CategoryId.ToString()
                //};

                //int bookId = bookDAO.AddBook(newBook, userId, context);

                //Book book = context.Books.ToList().Find(y => y.BookID == bookId);
                //book.GoogleBook = true;
                //book.DownloadLink = link;
                context.SaveChanges();
            }
        }
    }
}
