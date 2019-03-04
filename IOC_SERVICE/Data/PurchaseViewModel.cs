using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE.Data
{
   public class PurchaseViewModel
    {
        public int PurchaseId { get; set; }
        public int? InvoiceNumber { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int? Total { get; set; }
        public double? GrandTotal { get; set; }

        public int PartyId { get; set; }
        public string PartyName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }

        public int TaxId { get; set; }
        public int TaxRate { get; set; }

        public List<PurchaseDetailViewModel> purchasedetaillist { get; set; }
    }

    public class PurchaseDetailViewModel
    {
        public int PurchaseDetailId { get; set; }
        public int SaleId { get; set; }
        public int UnitPrice { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int SubTotal { get; set; }
        public int PurchaseUnit { get; set; }
    }

}


