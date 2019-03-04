using IOC_SERVICE.Data;
using IOC_SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOC_WEB.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public IItemService itemService;
        public ICategoryService categoryService;
        public IUnitService unitService;
        public ItemController(IItemService _itemService,ICategoryService _categoryService,IUnitService _unitService)
        {
            itemService = _itemService;
            categoryService = _categoryService;
            unitService = _unitService;
        }

        public ActionResult ItemView()
        {

            if (Session["UserId"] != null && (string)Session["Role"] == "Admin")
            {
                ViewBag.categories = categoryService.GetAll();
                ViewBag.units = unitService.GetAll();
                return View();
            }  
            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public JsonResult ItemDetails()
        {
            var itemData = itemService.GetAll();
            
            return Json(itemData,JsonRequestBehavior.AllowGet);
        }
       
        [HttpPost]
        public JsonResult SaveItem(ItemTypeModel item)
        {
            if (ModelState.IsValid)
            {
                itemService.Insert(item);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteItem(ItemTypeModel itemtypemodel)
        {
            var result = itemService.DeleteItem(itemtypemodel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ItemEdit(int id)
        {
            var itemData = itemService.GetById(id);

            return Json(itemData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateItem(ItemTypeModel itemmodel)
        {
            if (ModelState.IsValid)
            {
                itemService.Edit(itemmodel);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }
    }
}