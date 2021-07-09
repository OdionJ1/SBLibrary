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
    public class UserDAO : IUserDAO
    {
        private SBLibraryContext context;
        public UserDAO()
        {
            context = new SBLibraryContext();
        }

        //create user
        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public User GetUser(string email)
        {
            List<User> users = new List<User>();
            try
            {
                users = GetUsers().ToList();
                return users.FirstOrDefault(x => x.Email == email);
            }
            catch
            {
                throw;
            }
        }

          //call .Add and save to db
        public void CreateUsers(User user)
                {
                    try
                    {
                        context.Users.Add(user);
                        context.SaveChanges();
                    }
                    catch
                    {
                        throw;
                    }
                }

        public void AddBookToCollection(Book book, int UserID, SBLibraryContext context)
        {
            context.Users.ToList().Find(x => x.UserID == UserID).Books.Add(book);
        }
    }
}
