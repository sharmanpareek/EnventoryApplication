using IOC_SERVICE.Data;
using IOC_SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOC_WEB.Controllers
{
    public class SalesController : Controller
    {
        public IItemService _itemService;
        public IPartyService _partyService;
        public ISaleService _saleService;
        public ITaxService _taxService;
        public ISaleDetailService _saleDetailService;
        
        public SalesController(IItemService itemService, IPartyService partyService,ISaleService saleService, ITaxService taxService, ISaleDetailService saleDetailService)
        {
            _itemService = itemService;
            _partyService = partyService;
            _saleService = saleService;
            _taxService =taxService;
            _saleDetailService = saleDetailService;
        }

        public ActionResult SaleDetail()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            SaleViewModel saleviewmodel = new SaleViewModel();

            if (Session["UserId"] != null && (string)Session["Role"] == "Admin")
                ViewBag.SetLayout = "~/Views/Shared/_Layout.cshtml";
            else
            {
            
                saleviewmodel.BillNo = _saleService.ExecuteSp();
                saleviewmodel.CreatedDate = System.DateTime.Now;
                ViewBag.Items = _itemService.GetAll();
                ViewBag.Parties = _partyService.GetAll();
                ViewBag.taxes = _taxService.GetAll();
                ViewBag.SetLayout = "~/Views/Shared/_UserLayout.cshtml";
            }

            return View(saleviewmodel);
        }
        [HttpPost]
        public JsonResult SaleDetails()
        {
            if(Session["UserId"] != null && ((string)Session["Role"]=="User"))
            {
                int id = (int)System.Web.HttpContext.Current.Session["Id"];
                var saleDetail = _saleService.SaleDetail(id);
                return Json(saleDetail, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var saleDetail = _saleService.GetSaleDetail();
                return Json(saleDetail, JsonRequestBehavior.AllowGet);
            }
         
        }
        [HttpPost]
        public PartialViewResult SaleBillDetail(int id)
        {
            var billDetail = _saleService.SaleBillDetail(id);
            return PartialView("_BillDetail",billDetail);
        }
        [HttpPost]
        public JsonResult SaveSaleDetails(SaleViewModel saleViewModal)
        {

            int id = (int)System.Web.HttpContext.Current.Session["Id"];
            saleViewModal.UserId = id;
            _saleService.SaveSaleDetails(saleViewModal);
           
            return Json(true,JsonRequestBehavior.AllowGet);
        }
        
       

    }
}