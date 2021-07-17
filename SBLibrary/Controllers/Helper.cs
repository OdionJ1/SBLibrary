using SBLibrary.Service.IService;
using SBLibrary.Service.Service;
using SBLibrary.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBLibrary.Controllers
{
    public class Helper
    {
        CategoryService categoryService = new CategoryService();
        AuthorService authorService = new AuthorService();
        public List<SelectListItem> GetCategoryDropDown(int userId)
        {
            List<SelectListItem> categoryList = new List<SelectListItem>();
            IList<Category> categories = categoryService.GetCategories(userId);
            foreach (var item in categories)
            {
                categoryList.Add
                    (
                    new SelectListItem()
                    {
                        Text = item.CategoryName,
                        Value = item.CategoryId.ToString(), //should be 'item.ID.ToString()' but we don't have ID anymore
                        Selected = (item.CategoryName == (categories[0].CategoryName) ? true : false)
                    }
                    );
            }
            return categoryList;
        }

        public List<SelectListItem> GetAuthorDropDown(int userId)
        {
            List<SelectListItem> authorList = new List<SelectListItem>();
            IList<Author> authors = authorService.GetAuthors(userId);
            foreach (var item in authors)
            {
                authorList.Add
                    (
                    new SelectListItem()
                    {
                        Text = item.AuthorName,
                        Value = item.AuthorId.ToString(),
                        Selected = (item.AuthorId == (authors[0].AuthorId) ? true : false)
                    }
                    );
            }
            return authorList;
        }
    }
}