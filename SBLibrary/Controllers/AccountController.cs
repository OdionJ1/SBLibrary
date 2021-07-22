using SBLibrary.Data.Models.Domain;
using SBLibrary.Service.IService;
using SBLibrary.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SBLibrary.Controllers
{
    public class AccountController : Controller
    {
        IUserService userService;
        LoginService loginService;
        IBookService bookService;
        IAuthorService authorService;
        ICategoryService categoryService;

        public AccountController()
        {
            userService = new UserService();
            loginService = new LoginService();
            bookService = new BookService();
            authorService = new AuthorService();
            categoryService = new CategoryService();
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
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

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
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

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login loginmodel)
        {
            var user = loginService.UserAuthenticated(loginmodel);
            //Session["userId"] = user.UserID;
            if (user != null)
            {
                var Ticket = new FormsAuthenticationTicket(loginmodel.Email, true, 100);
                string Encrypt = FormsAuthentication.Encrypt(Ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, Encrypt);
                cookie.Expires = DateTime.Now.AddHours(100);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);
                if (user.RoleID == 1)
                {
                    //return RedirectToAction("GetBooks", "Book", new { id = user.UserID });
                    return RedirectToAction("GetBooks", "Book");
                }
                else
                {
                    //return RedirectToAction("AdminGetUsers", "Admin", new { id = user.UserID });
                    return RedirectToAction("AdminGetUsers", "Admin");
                }
                
            }
            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Register a user";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User usermodel)
        {
            if (ModelState.IsValid)
            {
                var user = userService.GetUser(usermodel.Email);
                if (user == null)
                {
                    userService.CreateUser(usermodel);
                    //return RedirectToAction("GetBooks", "Book", new { id = "UserID" });
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.message2 = "There is already a registered user with that email";
                }
                
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPassword resetmodel)
        {
            if (ModelState.IsValid)
            {
                //int userId =  (int) Session["userId"];
                //int userId = 0;

               userService.ResetPassword(resetmodel);
            }

            ViewBag.SuccessMessage = "The New Password is updated.";
            return RedirectToAction("Login", "Account");
        }

        public ActionResult GetBook(int id)
        {
            var book = bookService.GetBook(id);
            ViewBag.AuthorName = book.Author.AuthorName;
            ViewBag.AuthorId = book.Author.AuthorId;
            ViewBag.CategoryName = book.Category.CategoryName;
            ViewBag.CategoryId = book.Category.CategoryId;

            return View(book);
        }
    }
}
