using SBLibrary.Data.Models.Domain;
using SBLibrary.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Service.IService
{
    public interface IAuthorService
    {
        IList<Author> GetAuthors(int userId);

        IList<Book> GetBooks(int authorId);
        Author GetAuthor(string authorName);

        Author GetAuthor(int authorId);
        void AddAuthor(int userId, Author author);
    }
}
