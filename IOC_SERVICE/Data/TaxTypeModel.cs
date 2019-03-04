using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE.Data
{
    public class TaxTypeModel
    {
        [Key]
        public int TaxId { get; set; }
        [Required(ErrorMessage = "Fill Tax Rate")]
       
        public int TaxRate { get; set; }
        public bool IsDelete { get; set; }
        public List<SaleModel> salemodel { get; set; }
        public List<PurchaseModel> purchasemodel { get; set; }

    }
}
