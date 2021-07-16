using SBLibrary.Data.IDAO;
using SBLibrary.Data.DAO;
using SBLibrary.Data.Models.Domain;
using SBLibrary.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.DAO
{
    public class BookDAO : IBookDAO
    {
        private SBLibraryContext context;
        public BookDAO()
        {
            context = new SBLibraryContext();
        }

        //Add book to favourite list
        public void AddToFavList(int bookId, int userId, SBLibraryContext context)
        {
            Book book = GetBook(bookId, context);
            User user = context.Users.ToList().Find(y => y.UserID == userId);
            Favorite fav = new Favorite()
            {
                Book = book,
                User = user,
            };
            context.Favorites.Add(fav);
            context.SaveChanges();
        }

        //Remove book from favourite list
        public void RemoveFromFavList(int bookId, int userId, SBLibraryContext context)
        {
            try
            {
                var fav = context.Favorites.ToList().Find(y => y.Book.BookID == bookId && y.User.UserID == userId);
                context.Favorites.Remove(fav);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Remove book from Reading list
        public void RemoveFromReadList(int bookId, int userId, SBLibraryContext context)
        {
            try
            {
                var book = context.ReadLists.ToList().Find(y => y.Book.BookID == bookId && y.User.UserID == userId);
                context.ReadLists.Remove(book);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Add book to Reading list
        public void AddToReadList(int bookId, int userId, SBLibraryContext context)
        {
            Book book = GetBook(bookId, context);
            User user = context.Users.ToList().Find(y => y.UserID == userId);
            ReadList rlb = new ReadList()
            {
                Book = book,
                User = user,
            };
            context.ReadLists.Add(rlb);
            context.SaveChanges();
        }


        private User GetUser(int userId, SBLibraryContext context)
        {
            throw new NotImplementedException();
        }

        public IList<Book> GetFavouriteBooks(int userId, SBLibraryContext context)
        {
            bool find(Book book)
            {
                IList<Favorite> fav = context.Favorites.ToList();
                for (int i = 0; i < fav.Count(); i++)
                {
                    if (book.BookID == fav[i].Book.BookID && fav[i].User.UserID == userId)
                    {
                        return true;
                    }
                }
                return false;
            }
            var res = context.Books.ToList().FindAll(y => find(y));
            return res;
        }

        public IList<Book> GetReadList(int userId, SBLibraryContext context)
        {
            bool find(Book book)
            {
                IList<ReadList> rl = context.ReadLists.ToList();
                for (int i = 0; i < rl.Count(); i++)
                {
                    if (book.BookID == rl[i].Book.BookID && rl[i].User.UserID == userId)
                    {
                        return true;
                    }
                }
                return false;
            }
            var res = context.Books.ToList().FindAll(y => find(y));
            return res;
        }

        public void DelBook(int id, SBLibraryContext context)
        {
            try
            {
                Book book = context.Books.Find(id);
                context.Books.Remove(book);
                context.SaveChanges();

            }
            catch
            {
                throw;
            }

        }

        public Book EditBook(int id, SBLibraryContext context)
        {
            var eit = context.Books.Where(s => s.BookID == id).FirstOrDefault();

            return (eit);
        }

        public int EditBook(Book book)
        {
            try
            {
                context.Entry(book).State = EntityState.Modified;  //use user.data.entity for enter
                context.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get book in a list with specific id - implement details
        public Book GetBook(int id, SBLibraryContext context)
        {
            var res = context.Books.ToList().Find(y => y.BookID == id);
            return (res);
        }

        public IList<Book> GetBooks(SBLibraryContext context)
        {
            return context.Books.ToList();
        }

        //Get books in a list with thier id - implement details
        public IList<Book> GetBooks(int id, SBLibraryContext context)
        {
            var res = context.Books.ToList().FindAll(y => y.User.UserID == id);
            return res;
        }

        //Serch implimentation 
        public IList<Book> Search(string searchBy, string search, SBLibraryContext context)
        {
            if (searchBy == "Title")
            {
                var srch = context.Books.Where(x => x.Title.StartsWith(search) || search == null).ToList();
                return srch;
            }
            else
            {
                var srch = context.Books.Where(x => x.Author.AuthorName.StartsWith(search)).ToList();
                return srch;
            }
        }
    }
}
