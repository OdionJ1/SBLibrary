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
    public class AuthorDAO : IAuthorDAO
    {
        private SBLibraryContext context;
        public AuthorDAO()
        {
            context = new SBLibraryContext();
        }

        public Author GetAuthor(string authorName, SBLibraryContext context)
        {
            var res = context.Authors.ToList().Find(y => y.AuthorName == authorName);
            return (res);
        }

        public IList<Author> GetAuthors(int userId, SBLibraryContext context)
        {
            return context.Authors.ToList().FindAll(y => y.User.UserID == userId);
        }
        public void AddAuthor(int userId, Author author, SBLibraryContext context)
        {
            bool exist = false;
            var author1 = context.Authors.ToList().Find(y => y.AuthorName == author.AuthorName && y.User.UserID == userId);
            if(author1 != null)
            {
                exist = true;
            }
            if (!exist)
            {
                User user = context.Users.ToList().Find(y => y.UserID == userId);
                Author author2 = new Author()
                {
                    AuthorName = author.AuthorName,
                    User = user
                };
                context.Authors.Add(author2);
                context.SaveChanges();
            }
        }

        public void AddBook(Book book, Author author, SBLibraryContext context)
        {
            //context.Authors.Add(author); Not needed
            context.Books.Add(book);
        }

        //public void UploadBookToCollection(Book book, Author author, SBLibraryContext context)
        //{
        //    context.Authors.ToList().Find(x => x.AuthorName == author.AuthorName).Books.Add(book);
        //}

        //public Author GetAuthor(string id, SBLibraryContext context)
        //{

        //    var res = context.Authors.ToList().Find(y => y.AuthorName == id);
        //    return (res);
        //}
        //public IList<Author> GetAuthors(SBLibraryContext context)
        //{
        //    return context.Authors.ToList();
        //}
    }
}
