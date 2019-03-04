using IOC_SERVICE.Data;
using IOC_SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOC_WEB.Controllers
{
    public class CategoryController : Controller
    {
        public ICategoryService categoryService;
        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        // GET: Category
        public ActionResult CategoryView()
        {
            if (Session["UserId"] != null && (string)Session["Role"] == "Admin")
                return View();

            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public JsonResult CategoryDetails()
        {
            var categoryData = categoryService.GetAll();
            return Json(categoryData,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveCategory(CategoryModel category) 
        {
            if (ModelState.IsValid)
            {
                categoryService.Insert(category);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteCategories(CategoryModel categorymodel)
        {
            var result = categoryService.DeleteCategory(categorymodel);
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult CategoryEdit(int id)
        {
            var categoryData = categoryService.GetById(id);

            return Json(categoryData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateCategory(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                categoryService.Edit(category);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }

    }
}