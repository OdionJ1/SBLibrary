using SBLibrary.Data.Models.Domain;
using SBLibrary.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.IDAO
{
    public interface IAuthorDAO
    {
        //void UploadBookToCollection(Book book, Author author, SBLibraryContext context);

        IList<Author> GetAuthors(int userId, SBLibraryContext context);
        Author GetAuthor(string id, SBLibraryContext context);

        int EditAuthor(Author author);

        Author GetAuthor(int authorId, SBLibraryContext context);
        IList<Book> GetBooks(int authorId, SBLibraryContext context);

        void DelAuthor(int id, SBLibraryContext context);
        void AddAuthor(int userId, Author author, SBLibraryContext context);
    }
}
