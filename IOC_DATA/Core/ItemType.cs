using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_DATA.Core
{
   public class ItemType
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }

        public int Quantity { get; set; }
        public int Price { get; set; }

        public int UnitPrice { get; set; }
        public DateTime MfgDate { get; set; }
        public DateTime ExpDate { get; set; }

        public string ProductCompany { get; set; }

        public int CategoryId { get; set; }
        public int UnitId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Category category { get; set; }
        public virtual UnitType unit { get; set; }
        public  List<SaleDetail> saledetail { get; set; }

        public List<PurchaseDetail> purchasedetail { get; set; }



    }
}
