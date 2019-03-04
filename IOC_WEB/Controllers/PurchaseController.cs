using IOC_SERVICE.Data;
using IOC_SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOC_WEB.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        IPurchaseService purchaseService;
        IPartyService partyService;
        ITaxService taxService;
        IItemService itemService;

        public PurchaseController(IPurchaseService _purchaseService, IPartyService _partyService, ITaxService _taxService, IItemService _itemService)

        {
            purchaseService = _purchaseService;
            partyService = _partyService;
            taxService = _taxService;
            itemService = _itemService;
        }
        public ActionResult PurchaseDetail()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            PurchaseViewModel purchaseviewmodel = new PurchaseViewModel();
           
            if (Session["UserId"] != null && (string)Session["Role"] == "Admin")
                ViewBag.SetLayout = "~/Views/Shared/_Layout.cshtml";

            else
            {
                purchaseviewmodel.PurchaseDate = System.DateTime.Now;
                ViewBag.Parties = partyService.GetAll();
                ViewBag.taxes = taxService.GetAll();
                ViewBag.Items = itemService.GetAll();
                ViewBag.SetLayout = "~/Views/Shared/_UserLayout.cshtml";
            }
                
            return View(purchaseviewmodel);
        }
        [HttpPost]
        public JsonResult SavePurchaseDetails(PurchaseViewModel purchaseviewmodel)
        {
            var id = (int)System.Web.HttpContext.Current.Session["Id"];
            purchaseviewmodel.UserId = id;
            purchaseService.savePurchaseDetails(purchaseviewmodel);
            return Json(true,JsonRequestBehavior.AllowGet);
        }

      
        [HttpPost]
        public JsonResult purchaseDetails()
        {
            if (Session["UserId"] != null && ((string)Session["Role"] == "User"))
            {
                var id = (int)System.Web.HttpContext.Current.Session["Id"];
                var result = purchaseService.purchaseViewDetail(id);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = purchaseService.GetpurchaseViewDetail();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public PartialViewResult BillDetails(int id)
        {
            var billDetail = purchaseService.billDetail(id);
            return PartialView("_PurchaseBillDetail",billDetail);
        }
        [HttpPost]
        public JsonResult CancelBill(PurchaseModel purchasemodel)
        {
            var result = purchaseService.cancelbill(purchasemodel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}