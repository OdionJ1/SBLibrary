using SBLibrary.Data.Models.Domain;
using SBLibrary.Service.IService;
using SBLibrary.Service.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SBLibrary.Controllers
{
    public class BookController : Controller
    {
        IBookService bookService;
        IUserService userService;

        public BookController()
        {
            userService = new UserService();
            bookService = new BookService();
        }

        [Authorize]
        public ActionResult AddToFavList(int id)
        {
            bookService.AddToFavList(id, (int)Session["userId"]);
            return RedirectToAction("GetFavourite");
        }

        [Authorize]
        public ActionResult RemoveFromFavList(int id)
        {
            bookService.RemoveFromFavList(id, (int)Session["userId"]);
            return RedirectToAction("GetFavourite");
        }

        [Authorize]
        public ActionResult RemoveFromReadList(int id)
        {
            bookService.RemoveFromReadList(id, (int)Session["userId"]);
            return RedirectToAction("GetReadList");
        }

        [Authorize]
        public ActionResult AddToReadList(int id)
        {
            bookService.AddToReadList(id, (int)Session["userId"]);
            return RedirectToAction("GetReadList");
        }

        [Authorize]
        public ActionResult GetFavourite()
        {
            int userId = (int)Session["userId"];
            return View(bookService.GetFavouriteBooks(userId));
        }

        [Authorize]
        public ActionResult GetReadList()
        {
            int userId = (int)Session["userId"];
            return View(bookService.GetReadList(userId));
        }

        [Authorize]
        public ActionResult GetBooks()
        {
            var user = userService.GetUser(User.Identity.Name);
            if(user != null)
            {
                Session["userId"] = user.UserID;
            }
            var userId = (int)Session["userId"];
            return View(bookService.GetBooks(userId));
        }

        //Only a registered user will access the method
        [Authorize]
        public ActionResult EditBook(int id)
        {

            return View(bookService.EditBook(id));
        }

        //Only a registered user will access the method
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(Book edit)
        {
            if (ModelState.IsValid)
            {
                bookService.EditBook(edit);
                //return RedirectToAction("GetBooks", "Book", new { id = "UserID" });
                return RedirectToAction("GetBooks");
            }
            return View();
        }

        //[Authorize]
        //public ActionResult DelBook(int id)
        //{

        //    return View();
        //}

        public ActionResult ConfirmDel(int id)
        {
            //if (id > 0)
            //{
            //    bookService.DelBook(id);
            //    //return RedirectToAction("GetBooks", "Book", new { id = "UserID" });
            //    return RedirectToAction("GetBooks");
            //}
            return View("DelBook", bookService.GetBook(id));
        }


        [Authorize]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DelBook(int id)
        {
            if (id > 0)
            {
                bookService.DelBook(id);
                //return RedirectToAction("GetBooks", "Book", new { id = "UserID" });
                return RedirectToAction("GetBooks");
            }
            return View();
        }

        [Authorize]
        public ActionResult Search(string searchBy, string search)
        {
            return View(bookService.Search(searchBy, search));
        }

        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
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

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Book/Edit/5
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

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
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

        // GET: Upload Book
        [HttpGet]
        public ActionResult UploadBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadBook(HttpPostedFileBase file)
        {
            try
            {

                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }

        //public ActionResult Downloads()
        //{
        //    var dir = new System.IO.DirectoryInfo(Server.MapPath("~/UploadedFiles/"));
        //    System.IO.FileInfo[] fileNames = dir.GetFiles("*.*"); List<string> items = new List<string>();
        //    foreach (var file in fileNames)
        //    {
        //        items.Add(file.Name);
        //    }
        //    return View(items);
        //}

        public FileResult Download(int id)
        {
            // after add book is completed.. the below hardcode will be removed
            var FileVirtualPath = "~/UploadedFiles/"+ id + ".pdf";
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }


    }
}
