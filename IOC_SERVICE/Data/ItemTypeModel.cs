using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE.Data
{
    public class ItemTypeModel
    {
        [Key]
        public int ItemId { get; set; }
  
        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Please Enter Item Name")]
        [StringLength(100, ErrorMessage = "Name must not exceed {1} character")]
        [RegularExpression(@"^[ a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string ItemName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        
        //[StringLength(5, ErrorMessage = "Max 5 digits")]
        public int Price { get; set; }

        [Required]
        public int UnitPrice { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "MfgDate")]
        [Required(ErrorMessage = "Mfg Date is Required!")]
        public DateTime MfgDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "ExpDate")]
        [Required(ErrorMessage = "Expiary Date is Required!")]
        public DateTime ExpDate { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Please Enter Company Name")]
        [StringLength(100, ErrorMessage = "Name must not exceed {1} character")]
        [RegularExpression(@"^[ a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string ProductCompany { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
        
        public int UnitId { get; set; }
        public virtual CategoryModel categorymodel { get; set; }
        public virtual UnitTypeModel unitmodel { get; set; }
        public List<SaleDetailModel> saledetailmodel { get; set; }
        public List<PurchaseDetailModel> purchasedetailmodel { get; set; }



    }
}
