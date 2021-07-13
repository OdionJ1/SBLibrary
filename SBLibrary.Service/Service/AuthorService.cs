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
    public class AuthorService : IAuthorService
    {
        private AuthorDAO authorDAO;
        public AuthorService()
        {
            authorDAO = new AuthorDAO();
        }

        public IList<Author> GetAuthors(int userId)
        {
            using (var context = new SBLibraryContext())
            {
                return authorDAO.GetAuthors(userId, context);
            }

        }
        public Author GetAuthor(string authorName)
        {
            using (var context = new SBLibraryContext())
            {
                return authorDAO.GetAuthor(authorName, context);
            }

        }

        public void AddAuthor(int userId, Author author)
        {
            using (var context = new SBLibraryContext())
            {
                authorDAO.AddAuthor(userId, author, context);
            }
        }
    }
}
