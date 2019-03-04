using IOC_SERVICE.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.SERVICE.Data
{
    public class UserModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please Enter First Name")]
        [StringLength(100, ErrorMessage = "Name must not exceed {1} character")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please Enter Last Name")]
        [StringLength(100, ErrorMessage = "Name must not exceed {1} character")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                           ErrorMessage = "Email is not valid")]
       // [Remote("IsCheckedEmail", "User")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "password must be fill")]
        [MinLength(6, ErrorMessage = "password shoud be min 6 char")]
        [MaxLength(10, ErrorMessage = "password should be max 10 char")]
        public string Password { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        //
        public string MobileNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "DOB")]
        [Required(ErrorMessage = "DOB is Required!")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Fill Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        [StringLength(100, ErrorMessage = "Name must not exceed {1} character")]
        public string Address { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string Role { get; set; }

        public int Otp { get; set; }

      
        public List<SaleModel> salemodel { get; set; }
        public List<PurchaseModel> purchasemodel { get; set; }
        public string IsActiveStr { get; set; }
    }
}
