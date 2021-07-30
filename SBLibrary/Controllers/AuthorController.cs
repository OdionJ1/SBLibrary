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
    public class AuthorController : Controller
    {
        IAuthorService authorService;

        public AuthorController()
        {
            authorService = new AuthorService();
        }
        // GET: Author
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        public ActionResult GetAuthors()
        {
            return View(authorService.GetAuthors((int)Session["userId"]));
        }

        [Authorize(Roles = "User")]
        public ActionResult GetBooks(int authorId)
        {
            var author = authorService.GetAuthor(authorId);
            ViewBag.AuthorName = author.AuthorName;
            ViewBag.AuthorId = author.AuthorId;
            return View(authorService.GetBooks(authorId));
        }

        [Authorize(Roles = "User")]
        public ActionResult EditAuthor(int id)
        {
            return View(authorService.GetAuthor(id));
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAuthor(Author edit)
        {
            if (ModelState.IsValid)
            {
                authorService.EditAuthor(edit);

                return RedirectToAction("GetAuthors");
            }

            return View();
        }

        [Authorize(Roles = "User")]
        public ActionResult ConfirmDelete(int authorId)
        {
            var author = authorService.GetAuthor(authorId);
            ViewBag.AuthorName = author.AuthorName;
            ViewBag.AuthorId = author.AuthorId;
            return View(authorService.GetBooks(authorId));
        }

        [Authorize(Roles = "User")]
        public ActionResult DelAuthor(int id)
        {
            if (id > 0)
            {
                authorService.DelAuthor(id);
                return RedirectToAction("GetAuthors");
            }
            return View();
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Author/Create
        public ActionResult AddAuthor()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAuthor(Author authorModel)
        {
            if (ModelState.IsValid)
            {
                authorService.AddAuthor((int)Session["userId"], authorModel);
                return RedirectToAction("AddBook", "Book");
            }
            return View();
        }

        // POST: Author/Create
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

        // POST: Author/Edit/5
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

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Author/Delete/5
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
