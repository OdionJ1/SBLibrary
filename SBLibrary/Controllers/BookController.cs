using Aspose.Pdf;
using SBLibrary.Data.Models.Domain;
using SBLibrary.InServices.IService;
using SBLibrary.InServices.Service;
using SBLibrary.Models;
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
        IGoogleBookService googleBookService;
        Helper helper = new Helper();

        public BookController()
        {
            userService = new UserService();
            bookService = new BookService();
            googleBookService = new GoogleBookService();
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
            return View(bookService.Search(searchBy, (int)Session["userId"], search));
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
                        
                        string fileExt = Path.GetExtension(file.FileName);

                        if (fileExt.Equals(".epub") || fileExt.Equals(".pdf"))
                        {
                            int bookId = bookService.AddBook(book, (int)Session["userId"]);
                            string path = Path.Combine(Server.MapPath("~/UploadedFiles"), bookId + "_" + book.Name + fileExt);
                            file.SaveAs(path);

                            if (fileExt.Equals(".epub"))
                            {
                                string epubToPdfPath = Path.Combine(Server.MapPath("~/UploadedFiles"), bookId + "_" + book.Name + ".pdf");
                                ConvertEPUBtoPDF(path, epubToPdfPath);
                            }

                            return RedirectToAction("GetBooks");
                        }
                        else
                        {
                            ViewBag.categoryList = helper.GetCategoryDropDown((int)Session["userId"]);
                            ViewBag.authorList = helper.GetAuthorDropDown((int)Session["userId"]);
                            ViewBag.Message = "You can only upload pdf or epub files";
                            return View("AddBook");
                        }
                    }
                } else
                {
                    ViewBag.categoryList = helper.GetCategoryDropDown((int)Session["userId"]);
                    ViewBag.authorList = helper.GetAuthorDropDown((int)Session["userId"]);
                    ViewBag.Message = "You have not selected a file";
                    return View("AddBook");
                }
            }
            return View();
        }

        public static void ConvertEPUBtoPDF(string epubFilePath, string epubToPdfPath)
        {
            EpubLoadOptions option = new EpubLoadOptions();
            Document pdfDocument = new Document(epubFilePath, option);
            pdfDocument.Save(epubToPdfPath);
        }

        [Authorize(Roles = "User")]
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


        [Authorize(Roles = "User")]
        public FileResult Download(string id)
        {
            var FileVirtualPath = "~/UploadedFiles/" + id + ".pdf";
            return File(FileVirtualPath, "application/pdf", Path.GetFileName(FileVirtualPath));
        }

        [Authorize(Roles = "User")]
        public ActionResult ShareBook(int id)
        {
            return View("ShareBook", bookService.GetBook(id));
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShareBook(ShareBook book)
        {
            bookService.ShareBook(book);
            return RedirectToAction("GetBooks");
        }

        [Authorize(Roles = "User")]
        // [ValidateAntiForgeryToken]
        public ActionResult GoogleBooks()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult GoogleBooks(string searchBookName)
        {
            return View("GoogleBookList", googleBookService.GetGoogleBooks(searchBookName));
        }

        //[Authorize(Roles = "User")]
        //public ActionResult AddToBookList(string title, string author, string category, string link)
        //{
        //    bookService.AddToBookList((int)Session["userId"], title, author, category, link);
        //    return RedirectToAction("GetBooks");
        //}

        [Authorize(Roles = "User")]
        public ActionResult BuyBook(string title, string author, string category, string link)
        {
            Session["title"] = title;
            Session["author"] = author;
            Session["category"] = category;
            Session["link"] = link;
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuyBook(PaymentModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bookService.AddToBookList((int)Session["userId"], (string)Session["title"], (string)Session["author"], (string)Session["category"], (string)Session["link"]);
                    ViewBag.success = "Payment successful. Book successfully added to booklist";
                    return RedirectToAction("GetBooks");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return View();
        }
    }
}

