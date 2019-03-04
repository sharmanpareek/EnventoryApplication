using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_DATA.Core
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }

        public  int BillNo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Total { get; set; }
        public double? GrandTotal { get; set; }
        public int PartyId { get; set; }
        public int TaxId { get; set; }
        public int UserId { get; set; }
        public virtual TaxType tax { get; set; }
        public virtual PartyType party { get; set; }
        public virtual User user { get; set; }
        public List< SaleDetail> saledetail { get; set; }

    }
}
