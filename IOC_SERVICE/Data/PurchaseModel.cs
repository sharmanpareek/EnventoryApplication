using IOC.SERVICE.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE.Data
{
   public class PurchaseModel
    {
        [Key]
        public int PurchaseId { get; set; }
        [Required(ErrorMessage ="Invoice Number Must not be empty")]
        public int? InvoiceNumber { get; set; }
        [Required(ErrorMessage ="Date should be fill")]
        public DateTime? PurchaseDate { get; set; }

        [Required]
        public int? Total { get; set; }
        [Required]
        public double? GrandTotal { get; set; }

        public int PartyId { get; set; }
        public int UserId { get; set; }
        public int TaxId { get; set; }
      
        public virtual TaxTypeModel tax { get; set; }
        public virtual PartyTypeModel party { get; set; }
        public virtual UserModel user { get; set; }

        public List<PurchaseDetailModel> purchasedetail { get; set; }
    }
}
