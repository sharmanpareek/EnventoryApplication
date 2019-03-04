using IOC.SERVICE.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE.Data
{
   public class SaleDetailModel
    {
        [Key]
        public int SaleDetailId { get; set; }

      
        public int ItemId { get; set; }
        public int UnitPrice { get; set; }
        public int SubTotal { get; set; }
        public int SaleId { get; set; }
       
        public int UnitSold { get; set; }
        public int PartyId { get; set; }

        public virtual SaleModel salemodel { get; set; }

        public virtual ItemTypeModel itemtypemodel { get; set; }

        public virtual UserModel usermodel { get; set; }
    }
}
