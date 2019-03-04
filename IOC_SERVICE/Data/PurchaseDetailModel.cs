using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE.Data
{
   public class PurchaseDetailModel
    {
        [Key]
        public int PurchaseDetailId { get; set; }
        public int ItemId { get; set; }
        [Required]
        public int PurchaseUnit { get; set; }
        [Required]
        public int UnitPrice { get; set; }
        [Required]
        public int SubTotal { get; set; }

        public virtual PurchaseModel purchase { get; set; }
        public virtual ItemTypeModel itemtype { get; set; }
    }
}
