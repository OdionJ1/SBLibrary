using SBLibrary.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.Models.Repository
{
    public class SBLInitializer : System.Data.Entity.DropCreateDatabaseAlways<SBLibraryContext>
    {
        protected override void Seed(SBLibraryContext context)
        {
            var users = new List<User>
            {
                new User() { FirstName = "Sath", LastName = "rav", Email = "abc@gmail.com", Mobile = "1234567890", Password = "Test@123" },
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book() { Title = "Are you afraid of the Dark", Date = Convert.ToDateTime("12/12/2020") },
                new Book() { Title = "Lenny the Lobster Can't Stay for Dinner", Date = Convert.ToDateTime("12/12/2020") },
                new Book() { Title = "The Boy Who Steals Houses Paperback", Date = Convert.ToDateTime("12/12/2020") },
             };

            books.ForEach(s => {
                s.User = users[0];
                context.Books.Add(s);
            }
            );
            context.SaveChanges();

            var authors = new List<Author>
            {
                new Author() { AuthorName = "Sidney Sheldon" },
                new Author(){ AuthorName = " Catherine Meurisse" },
                new Author(){ AuthorName = "C.G. Drews"}
            };

            authors.ForEach(s => context.Authors.Add(s));
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category() { CategoryName = "Horror"},
                new Category() { CategoryName = "Comic"},
            };

            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            //var readlists = new List<ReadList>
            //{
            //    new ReadList() { },
            //};

            //readlists.ForEach(s => context.ReadLists.Add(s));
            //context.SaveChanges();

            //var favorites = new List<Favorite>
            //{
            //    new Favorite() { },
            //};

            //favorites.ForEach(s => context.Favorites.Add(s));
            //context.SaveChanges();
        }

    }
}
