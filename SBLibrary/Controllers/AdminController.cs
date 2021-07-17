using SBLibrary.Service.IService;
using SBLibrary.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBLibrary.Controllers
{
    public class AdminController : Controller
    {
        IAdminService adminService;


        public AdminController()
        {
            adminService = new AdminService();

        }
        [Authorize(Roles = "Admin")]
        public ActionResult AdminGetUsers()
        {
            return View(adminService.AdminGetUsers());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminDelUser(int id)
        {
            if (id > 0)
            {
                adminService.AdminDelUser(id);
                return RedirectToAction("AdminGetUsers");
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminConfirmUserDel(int id)
        {
            return View("AdminDelUser", adminService.AdminGetUser(id));
        }

    }
}
