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
using System.IO;

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

            List<ShareBook> sharedBooks = context.ShareBooks.ToList().FindAll(y => y.UserID == id);

            List<int> sharedBookIds = new List<int>();
            sharedBooks.ForEach(s => sharedBookIds.Add(s.BookID));

            var sBooks = context.Books.ToList().FindAll(y => sharedBookIds.Contains(y.BookID));

            sBooks.ForEach(x => res.Add(x));
            return res;
        }

        //Serch implimentation 
        public IList<Book> Search(string searchBy, int userId, string search, SBLibraryContext context)
        {
            if (searchBy == "Title")
            {
                var srch = context.Books.ToList().FindAll(y => y.Title.StartsWith(search) && y.User.UserID == userId || search == null);
                //var srch = context.Books.Where(x => x.Title.StartsWith(search) || search == null).ToList();
                return srch;
            }
            else
            {
                var srch = context.Books.ToList().FindAll(y => y.Author.AuthorName.StartsWith(search) && y.User.UserID == userId || search == null);
                //var srch = context.Books.Where(x => x.Author.AuthorName.StartsWith(search)).ToList();
                return srch;
            }
        }

        public int AddBook(UploadBook uploadBook, int userId, SBLibraryContext context)
        {
            Book newBook = new Book()
            {//Dress up Book object using values of attributes
                Title = uploadBook.Name,
                Date = DateTime.Now,
            };

            User currentUser = context.Users.ToList().Find(x => x.UserID == userId);
            newBook.User = currentUser;

            Category bookCatagory = context.Categories.ToList().Find(y => y.CategoryId.ToString() == uploadBook.Category);
            newBook.Category = bookCatagory;

            Author currentAuthor = context.Authors.ToList().Find(y => y.AuthorId.ToString() == uploadBook.Author);
            newBook.Author = currentAuthor;

            context.Books.Add(newBook);
            context.SaveChanges();

            return newBook.BookID;
        }

        public void ShareBook(ShareBook shareBook, SBLibraryContext context)
        {
            //context.Users.ToList().Find
            User sharedUser = context.Users.ToList().Find(user => user.Email == shareBook.EmailID);


            if (sharedUser != null)
            {
                IQueryable<ShareBook> sharedBook = context.ShareBooks.Where(x => x.BookID == shareBook.BookID && x.UserID == sharedUser.UserID);

                int booksCount = sharedBook.Count();


                if (booksCount == 0)
                {
                    shareBook.UserID = sharedUser.UserID;

                    context.ShareBooks.Add(shareBook);
                    context.SaveChanges();
                }

            }

        }

    }
}
