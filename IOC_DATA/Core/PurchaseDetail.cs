using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_DATA.Core
{
   public class PurchaseDetail
    {
        public int PurchaseDetailId { get; set; }
        public int ItemId { get; set; }
        public int PurchaseUnit { get; set; }
        public int UnitPrice { get; set; }
        public int SubTotal { get; set; }
        public int PurchaseId { get; set; }

        public virtual Purchase purchase { get; set; }
        public virtual ItemType itemtype { get; set; }
    }
}
