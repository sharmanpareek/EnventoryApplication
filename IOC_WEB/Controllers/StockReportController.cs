using IOC_SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOC_WEB.Controllers
{
    public class StockReportController : Controller
    {
        // GET: StockReport
        public IItemService itemservice;
        public StockReportController(IItemService _itemservice)
        {
            itemservice = _itemservice;
        }
        public ActionResult ReportView()
        {
            if (Session["UserId"] != null && (string)Session["Role"] == "Admin")
                return View();

            return RedirectToAction("Login", "User");
       
        }
        [HttpPost]
        public JsonResult Reports()
        {
            var result = itemservice.GetReport();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}