﻿using SBLibrary.Data.Models.Domain;
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
        Helper helper = new Helper();

        public BookController()
        {
            userService = new UserService();
            bookService = new BookService();
        }

        [Authorize (Roles = "User")]
        public ActionResult AddToFavList(int id)
        {
            bookService.AddToFavList(id, (int)Session["userId"]);
            return RedirectToAction("GetFavourite");
        }

        [Authorize(Roles = "User")]
        public ActionResult RemoveFromFavList(int id)
        {
            bookService.RemoveFromFavList(id, (int)Session["userId"]);
            return RedirectToAction("GetFavourite");
        }

        [Authorize(Roles = "User")]
        public ActionResult RemoveFromReadList(int id)
        {
            bookService.RemoveFromReadList(id, (int)Session["userId"]);
            return RedirectToAction("GetReadList");
        }

        [Authorize(Roles = "User")]
        public ActionResult AddToReadList(int id)
        {
            bookService.AddToReadList(id, (int)Session["userId"]);
            return RedirectToAction("GetReadList");
        }

        [Authorize(Roles = "User")]
        public ActionResult GetFavourite()
        {
            int userId = (int)Session["userId"];
            return View(bookService.GetFavouriteBooks(userId));
        }

        [Authorize(Roles = "User")]
        public ActionResult GetReadList()
        {
            int userId = (int)Session["userId"];
            return View(bookService.GetReadList(userId));
        }

        [Authorize(Roles = "User")]
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
        [Authorize(Roles = "User")]
        public ActionResult EditBook(int id)
        {

            return View(bookService.EditBook(id));
        }

        //Only a registered user will access the method
        [Authorize(Roles = "User")]
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


        [Authorize(Roles = "User")]
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

        [Authorize(Roles = "User")]
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
        public ActionResult AddBook()
        {
            ViewBag.categoryList = helper.GetCategoryDropDown((int)Session["userId"]);
            ViewBag.authorList = helper.GetAuthorDropDown((int)Session["userId"]);
            return View();
        }

        // POST: Book/Upload
        [Authorize(Roles = "User")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddBook(UploadBook book, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    if (file.ContentLength > 0)
                    {
                        int bookId = bookService.AddBook(book, (int)Session["userId"]);

                        string fileExt = Path.GetExtension(file.FileName);
                        string path = Path.Combine(Server.MapPath("~/UploadedFiles"), bookId + "_" + book.Name + fileExt);
                        file.SaveAs(path);
                    }
                    return RedirectToAction("GetBooks");
                }
            }
            return View();
        }
        public ActionResult ReadBook(int id, string name)
        {
            string bookName = id + "_" + name;
            //string fileExt = ".?";
            string path = Path.Combine(Server.MapPath("~/UploadedFiles"), id + "_" + name + ".pdf");
            string contentType = "application/pdf";

            return new FilePathResult(path, contentType);

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

        public FileResult Download(string id)
        {
            var FileVirtualPath = "~/UploadedFiles/" + id + ".pdf";
            return File(FileVirtualPath, "application/pdf", Path.GetFileName(FileVirtualPath));
        }

        public ActionResult ShareBook(int id)
        {
            return View("ShareBook", bookService.GetBook(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShareBook(ShareBook book)
        {
            bookService.ShareBook(book);
            return RedirectToAction("GetBooks");
        }
    }
}

