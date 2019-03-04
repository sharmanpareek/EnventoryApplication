using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE.Data
{
    public class PartyTypeModel
    {
        [Key]
        public int PartyId { get; set; }
        [Required(ErrorMessage = "Please Enter Party Name")]
        [StringLength(100, ErrorMessage = "Name must not exceed {1} character")]
        [RegularExpression(@"^[ a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string PartyName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Please Enter Address")]
        [StringLength(100, ErrorMessage = "Name must not exceed {1} character")]
        public string Address { get; set; }

        public bool IsDelete { get; set; }
        public List<SaleModel> salemodel { get; set; }
        public List<PurchaseModel> purchasemodel { get; set; }
    }
}

