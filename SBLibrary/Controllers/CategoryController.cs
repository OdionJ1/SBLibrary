using SBLibrary.Data.Models.Domain;
using SBLibrary.Service.IService;
using SBLibrary.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBLibrary.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService categoryService;

        public CategoryController()
        {
            categoryService = new CategoryService();
        }
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult AddCategory()
        {
            return View();
        }

        [Authorize]
        public ActionResult GetCategories()
        {
            return View(categoryService.GetCategories((int)Session["userId"]));
        }

        [Authorize]
        public ActionResult GetBooks(int categoryId)
        {
            var category = categoryService.GetCategory(categoryId);
            ViewBag.CategoryName = category.CategoryName;
            return View(categoryService.GetBooks(categoryId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(Category categoryModel)
        {
            if (ModelState.IsValid)
            {
                categoryService.AddCategory((int)Session["userId"], categoryModel);
                return RedirectToAction("AddBook", "Book");
            }
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
