using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE.Data
{
    public class SaleModel
    {
        [Key]
        public int SaleId { get; set; }
        [Required]
        public int BillNo { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Please Select Date")]
        public DateTime CreatedDate { get; set; }
        [Required]
        public int Total { get; set; }
        public int UserId { get; set; }
        [Required]
        public float GrandTotal { get; set; }
        public int PartyId { get; set; }
        public int TaxId { get; set; }
        public virtual TaxTypeModel taxmodel { get; set; }
        public virtual PartyTypeModel partymodel { get; set; }

        public List<SaleDetailModel> saledetailmodel { get; set; }
    }
}
