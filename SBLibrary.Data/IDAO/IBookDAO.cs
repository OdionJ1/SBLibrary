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
        Book GetBook(int id, SBLibraryContext context);
        IList<Book> GetBooks(int id, SBLibraryContext context);

        Book EditBook(int id, SBLibraryContext context);
        void EditBook(Book edit);

        //Delete
        //Book DelBook(int id, SBLibraryContext context);
        //void DelBooks(Book del, SBLibraryContext context);


        //IList<Book> DelBooks(int id, SBLibraryContext context);

        //void AddBook(Book book, SBLibraryContext context);
        //void AddBook(Book book,  Author author, SBLibraryContext context);
        //void AddBook(Book book, Category categories, SBLibraryContext context);
    }
}
