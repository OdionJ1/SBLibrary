using SBLibrary.Data.Models.Domain;
using SBLibrary.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Service.IService
{
    public interface ICategoryService
    {
        IList<Category> GetCategories(int userId);
        Category GetCategory(string categoryName);

        Category GetCategory(int categoryId);

        int EditCategory(Category category);

        IList<Book> GetBooks(int categoryId);

        void DelCategory(int id);
        void AddCategory(int userId, Category category);
    }
}
