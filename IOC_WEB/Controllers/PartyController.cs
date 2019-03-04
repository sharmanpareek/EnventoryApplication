using IOC_SERVICE.Data;
using IOC_SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOC_WEB.Controllers
{
    public class PartyController : Controller
    {
        public IPartyService partyService;

        public PartyController(IPartyService _partyService)
        {
            partyService = _partyService;

        }
        // GET: Party
        [HttpGet]
        public ActionResult PartyView()
        {


            if (Session["UserId"] != null && (string)Session["Role"] == "Admin")
                return View();

            return RedirectToAction("Login", "User");
        }
       
        public JsonResult PartyDetails()
        {
            var partyData = partyService.GetAll();

            return Json(partyData,JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult SaveParty()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SaveParty(PartyTypeModel partymodel)
        {
            if(ModelState.IsValid)
            {
                partyService.Insert(partymodel);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
            

        }
       
        [HttpGet]
        public JsonResult PartyEdit(int id)
        {
            var partyData = partyService.GetById(id);

            return Json(partyData,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateParty(PartyTypeModel partymodel)
        {
            if(ModelState.IsValid)
            {
                partyService.Edit(partymodel);
                return Json(true,JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
           
        }

        [HttpPost]
        public JsonResult UpdatePartyStatus(PartyTypeModel partymodel)
        {
            var result=partyService.DeleteParty(partymodel);
            return Json(result,JsonRequestBehavior.AllowGet);
        }

    }
}