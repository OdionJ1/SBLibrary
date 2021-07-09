using SBLibrary.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.Models.Repository
{
    public class SBLInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SBLibraryContext>
    {
        protected override void Seed(SBLibraryContext context)
        {
            var users = new List<User>
            {
                new User() { FirstName = "", LastName = "", Email = "", Mobile = "", Password = "" },
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book() { },
            };

            books.ForEach(s => context.Books.Add(s));
            context.SaveChanges();

            var authors = new List<Author>
            {
                new Author() { },
            };

            authors.ForEach(s => context.Authors.Add(s));
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category() { },
            };

            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            var readlists = new List<ReadList>
            {
                new ReadList() { },
            };

            readlists.ForEach(s => context.ReadLists.Add(s));
            context.SaveChanges();

            var favorites = new List<Favorite>
            {
                new Favorite() { },
            };

            favorites.ForEach(s => context.Favorites.Add(s));
            context.SaveChanges();
        }

    }
}
