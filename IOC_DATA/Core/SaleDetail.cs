using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_DATA.Core
{
    public class SaleDetail
    {
        [Key]
        public int SaleDetailId { get; set; }
      
        public int ItemId { get; set; }
       
        public int SaleId { get; set; }
    
        public int UnitSold { get; set; }
        public int SubTotal { get; set; }
        public int UnitPrice { get; set; }


        public virtual Sale sale { get; set; }

        public virtual ItemType itemtype { get; set; }
       
      


    }
}
