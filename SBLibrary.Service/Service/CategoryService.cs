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
    public class CategoryService : ICategoryService
    {
        private CategoryDAO categoryDAO;
        public CategoryService()
        {
            categoryDAO = new CategoryDAO();
        }

        public IList<Category> GetCategories(int userId)
        {
            using (var context = new SBLibraryContext())
            {
                return categoryDAO.GetCategories(userId, context);
            }
        }

        public Category GetCategory(string categoryName)
        {
            using (var context = new SBLibraryContext())
            {
                return categoryDAO.GetCategory(categoryName, context);
            }
        }

        public Category GetCategory(int categoryId)
        {
            using (var context = new SBLibraryContext())
            {
                return categoryDAO.GetCategory(categoryId, context);
            }
        }

        public IList<Book> GetBooks(int categoryId)
        {
            using (var context = new SBLibraryContext())
            {
                return categoryDAO.GetBooks(categoryId, context);
            }
        }

        public void AddCategory(int userId, Category category)
        {
            using (var context = new SBLibraryContext())
            {
                categoryDAO.AddCategory(userId, category, context);
            }
        }
    }
}
