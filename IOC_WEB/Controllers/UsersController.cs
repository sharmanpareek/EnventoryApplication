using IOC.SERVICE.Data;
using IOC_SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOC_WEB.Controllers
{
    public class UsersController : Controller
    {
        private IUserService userService;
        public UsersController(IUserService _userservice)
        {
            userService = _userservice;

        }
        // GET: Users
        public ActionResult UserDashboard()
        {
            if (Session["UserId"] != null && (string)Session["Role"] == "User")
                return View();

            return RedirectToAction("Login", "User");


        }
       
        public ActionResult UserView()
        {
            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Login", "User");
            //}
            if (Session["UserId"] != null && ((string)Session["Role"] == "User"))
            {

                int id = (int)System.Web.HttpContext.Current.Session["Id"];
                var UserInfo = userService.GetById(id);
                //UserInfo.DOB = UserInfo.DOB.
                return View(UserInfo);
            }
            return RedirectToAction("Login", "User");
        }
        public JsonResult UpdateUser(UserModel usermodel)
        {
          
            ModelState.Remove("Email");
            ModelState.Remove("Password");
            if (ModelState.IsValid)
            {
                userService.UpdateUserProfile(usermodel);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false,JsonRequestBehavior.AllowGet);
        }


    }
}