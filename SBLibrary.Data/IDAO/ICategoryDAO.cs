using SBLibrary.Data.Models.Domain;
using SBLibrary.Data.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBLibrary.Data.IDAO
{
    public interface ICategoryDAO
    {
        //void UploadBookToCollection(Book book, Category category, SBLibraryContext context);

        IList<Category> GetCategories(int userId, SBLibraryContext context);
        Category GetCategory(string categoryName, SBLibraryContext context);

        Category GetCategory(int categoryId, SBLibraryContext context);

        int EditCategory(Category category);

        IList<Book> GetBooks(int categoryId, SBLibraryContext context);
        void AddCategory(int userId, Category category, SBLibraryContext context);
    }
}
