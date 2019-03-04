using IOC_SERVICE.Data;
using IOC_SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOC_WEB.Controllers
{
    public class TaxController : Controller
    {
        public ITaxService _taxService;

        public TaxController(ITaxService taxService)
        {
            _taxService = taxService;
        }
        public ActionResult TaxView()
        {

            if (Session["UserId"] != null && (string)Session["Role"] == "Admin")
                return View();

            return RedirectToAction("Login", "User");
        }
        public JsonResult TaxDetails()
        {
            var tax = _taxService.GetAll();
            return Json(tax,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveTax(TaxTypeModel taxmodel)
        {
            if (ModelState.IsValid)
            {
                _taxService.Insert(taxmodel);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult DeleteTax(TaxTypeModel taxmodel)
        {
            var result = _taxService.Deletetax(taxmodel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult TaxEdit(int id)
        {
            var taxData = _taxService.GetById(id);

            return Json(taxData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateTax(TaxTypeModel taxmodel)
        {
            if (ModelState.IsValid)
            {
                _taxService.Edit(taxmodel);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }
    }
}