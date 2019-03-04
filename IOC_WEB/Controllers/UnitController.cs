using IOC_SERVICE.Data;
using IOC_SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOC_WEB.Controllers
{
    public class UnitController : Controller
    {
        // GET: Unit
      public  IUnitService unitService;

        public UnitController(IUnitService _unitService)
        {
            unitService = _unitService;
        }
        public ActionResult UnitView()
        {

            if (Session["UserId"] != null && (string)Session["Role"] == "Admin")
                return View();

            return RedirectToAction("Login", "User");
        }
        [HttpGet]
        public JsonResult  UnitDetails()
        {
            var unitData = unitService.GetAll();
            return Json(unitData,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveUnit(UnitTypeModel unitmodel)
        {
            if (ModelState.IsValid)
            {
                unitService.Insert(unitmodel);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
         
        }

        [HttpPost]
        public JsonResult DeleteUnits(UnitTypeModel unitmodel)
        {
            var result = unitService.DeleteUnit(unitmodel);
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult UnitEdit(int id)
        {
            var unitData = unitService.GetById(id);

            return Json(unitData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateUnit(UnitTypeModel unitmodel)
        {
            if (ModelState.IsValid)
            {
                unitService.Edit(unitmodel);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);

        }


    }
}