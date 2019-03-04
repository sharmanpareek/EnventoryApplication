using IOC_DATA.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE.Data
{
     public class SaleViewModel
    {
        public int BillNo { get; set; }
        public int SaleId { get; set; }
        public int UserId { get; set; }
        
        public int TaxId { get; set; }
        public int TaxRate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public double? GrandTotal { get; set; }
        public int? Total { get; set; }
        public int PartyId { get; set; }
        public string PartyName { get; set; }
        public string  Address { get; set; }
        public string Contact { get; set; }
        public string FirstName { get; set; }

        public List<SaleDetailViewModel> SaleDetailList { get; set; }
    }
    public class SaleDetailViewModel
    {
        public int SaleDetailId { get; set; }
        public int SaleId { get; set; }
        public int UnitPrice { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int SubTotal { get; set; }
        public int UnitSold { get; set; }
        public string UnitTypes { get; set; }
        public int UnitId { get; set; }
        public int Quantity { get; set; }

    }
}

