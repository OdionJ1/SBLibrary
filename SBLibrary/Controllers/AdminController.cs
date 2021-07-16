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
        public ActionResult AdminGetUsers()
        {
            return View(adminService.AdminGetUsers());
        }

        [Authorize]
        public ActionResult AdminDelUser(int id)
        {
            if (id > 0)
            {
                adminService.AdminDelUser(id);
                return RedirectToAction("AdminGetUsers");
            }
            return View();
        }

        public ActionResult AdminConfirmUserDel(int id)
        {
            return View("AdminDelUser", adminService.AdminGetUser(id));
        }

    }
}
