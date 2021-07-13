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
        Author GetAuthor(string authorName);
        void AddAuthor(int userId, Author author);
    }
}
