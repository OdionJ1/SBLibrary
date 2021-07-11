using SBLibrary.Data.IDAO;
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
