using IOC.SERVICE.Data;
using IOC_SERVICE.IService;
using IOC_WEB.PasswordSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IOC_WEB.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public IUserService _userService;



        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
       
        [HttpGet]
        public ActionResult UserSave()
        {
            if (Session["UserId"] != null)
                return RedirectToAction("AdminDashboard", "Admin");

            else if (Session["UserId"] != null)
                return RedirectToAction("UserDashboard", "Users");

            return View();
        }
        [HttpPost]
        public JsonResult UserSave(UserModel user)
        {
            Encryption encrypt = new Encryption();
            string password = encrypt.Encrypt(user.Password);

            if (ModelState.IsValid)
            {
                user.Password = password;
                _userService.Insert(user);

                return Json(true, JsonRequestBehavior.AllowGet);
            }
           
                return Json(false, JsonRequestBehavior.AllowGet);
           
           
        }
        [AllowAnonymous]
        public string CheckUserName(string input)
        {
            bool ifuser = _userService.EmailExist(input);

            if (ifuser == false)
            {
                return "Available";
            }

            if (ifuser == true)
            {
                return "Not Available";
            }

            return "";
        }
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["UserId"] != null && ((string)Session["Role"] == "Admin"))
                return RedirectToAction("AdminDashboard", "Admin");

            else if (Session["UserId"] != null && ((string)Session["Role"] == "User"))
                return RedirectToAction("UserDashboard", "Users");

            return View();

        }
        [HttpPost]
        public JsonResult Login(UserModel user)
        {

            if (user.Email != null && user.Password != null)
            {

                FormsAuthentication.SetAuthCookie(user.Email, false);
                Encryption encrypt = new Encryption();
                string password = encrypt.Encrypt(user.Password);
                user.Password = password;
          
                var _user = _userService.Login(user.Email, user.Password);
                if (_user.Email == null && _user.Password == null)
                    return Json("Incorrect UserName and Password");
                else
                {
                    if (_user.Role == "Admin" && _user.IsActive==true)
                    {
                        Session["UserId"] = _user.Email;
                        Session["Role"] = _user.Role;

                    }
                    else if (_user.Role == "User" && _user.IsActive == true)
                    {
                        Session["UserId"] = _user.Email;
                        Session["Id"] = _user.UserId;
                        Session["Role"] = _user.Role;


                    }
                }

                return Json(_user.Role);
            }
            else
                return Json("Please fill your details correctly");
        }
        public ActionResult ForgotPassword()
        {

            return View();
        }
        [HttpPost]
        public JsonResult ForgotPassword(UserModel user)
        {
            return Json(true,JsonRequestBehavior.AllowGet);
        }
        public JsonResult ChangePassword()
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult VerifyOTP()
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return Json(true, JsonRequestBehavior.AllowGet);

        }
    }
}