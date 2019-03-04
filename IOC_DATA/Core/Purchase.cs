using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_DATA.Core
{
  public  class Purchase
    {
        public int PurchaseId { get; set; }
        public int? InvoiceNumber { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public int? Total { get; set; }
        public double? GrandTotal { get; set; }

        public int PartyId { get; set; }
        public int UserId { get; set; }
        public int TaxId { get; set; }
        
        public virtual TaxType tax { get; set; }
        public virtual PartyType party { get; set; }
        public virtual User user { get; set; }
        public bool IsDeleted { get; set; }
        public List<PurchaseDetail> purchasedetail { get; set; }

    }
}
