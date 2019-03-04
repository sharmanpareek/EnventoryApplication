using IOC.SERVICE.Data;
using IOC_SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOC_WEB.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public IUserService userService;
        public AdminController(IUserService _userService)
        {
            userService = _userService;

        }
        public ActionResult AdminDashboard()
        {
            if (Session["UserId"] != null && (string)Session["Role"] == "Admin")
                return View();

            return RedirectToAction("Login", "User");
        }
        public ActionResult UserView()
        {
            if (Session["UserId"] != null && (string)Session["Role"] == "Admin")
                return View();

            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public JsonResult UserDetails()
        {
            var Users = userService.GetAll();
            return Json(Users, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UserInfo()
        {
            if (Session["UserId"] != null && (string)Session["Role"] == "Admin")
                return View();

            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public JsonResult UserPersonalInfo()
        {
            var UserInfo = userService.GetAll();
            return Json(UserInfo,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ActiveUser(UserModel usermodel)
        {
             userService.ActiveUser(usermodel);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
 
     
    }
}