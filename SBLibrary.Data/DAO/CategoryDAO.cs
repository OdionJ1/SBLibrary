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
    public class CategoryDAO : ICategoryDAO
    {
        private SBLibraryContext context;
        public CategoryDAO()
        {
            context = new SBLibraryContext();
        }

        public Category GetCategory(string categoryName, SBLibraryContext context)
        {
            var res = context.Categories.ToList().Find(y => y.CategoryName == categoryName);
            return (res);
        }

        public IList<Category> GetCategories(int userId, SBLibraryContext context)
        {
            return context.Categories.ToList().FindAll(y => y.User.UserID == userId);
        }

        public void AddCategory(int userId, Category category, SBLibraryContext context)
        {
            bool exist = false;
            var category1 = context.Categories.ToList().Find(y => y.CategoryName == category.CategoryName && y.User.UserID == userId);
            if (category1 != null)
            {
                exist = true;
            }
            if (!exist)
            {
                User user = context.Users.ToList().Find(y => y.UserID == userId);
                Category category2 = new Category()
                {
                    CategoryName = category.CategoryName,
                    User = user
                };
                context.Categories.Add(category2);
                context.SaveChanges();
            }
        }

    }
}
