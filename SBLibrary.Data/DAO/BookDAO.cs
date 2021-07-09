using SBLibrary.Data.IDAO;
using SBLibrary.Data.Models.Domain;
using SBLibrary.Data.Models.Repository;
using System;
using System.Collections.Generic;
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

        //public Book DelBook(int id, SBLibraryContext context)
        //{
        //    var del = context.Books.Where(s => s.BookID == id).FirstOrDefault();

        //    return (del);
        //}

        //public void DelBooks(Book del, SBLibraryContext context)
        //{
        //    try
        //    {
        //        context.Books.Remove(del);
        //        context.SaveChanges();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

       

        public Book EditBook(int id, SBLibraryContext context)
        {
            var eit = context.Books.Where(s => s.BookID == id).FirstOrDefault();

            return (eit);
        }

        public void EditBook(Book edit)
        {
            {
                try
                {
                    context.Books.Add(edit);
                    context.SaveChanges();
                }
                catch
                {
                    throw;
                }
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
            var res = context.Books.ToList();
            return res;
        }
        //public Book GetBook(int UserID, SBLibraryContext context)
        //{
        //    var res = context.Books.ToList().Find(y => y.UserID == UserID);
        //    return (res);
        //}

        //public void AddBook(Book book, SBLibraryContext context)
        //{
        //    context.Books.Add(book);
        //}

        //public void AddBook(Book book, Author author, SBLibraryContext context)
        //{
        //    context.Books.Add(book);
        //}

        //public void AddBook(Book book, Category categories, SBLibraryContext context)
        //{
        //    context.Books.Add(book);
        //}
    }
}
