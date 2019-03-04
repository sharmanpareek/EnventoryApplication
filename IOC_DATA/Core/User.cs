using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_DATA.Core
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
       
        public string FirstName { get; set; }

       
        public string LastName { get; set; }


    
        // [Remote("IsCheckedEmail", "User")]
        public string Email { get; set; }

    
        public string Password { get; set; }

        public string MobileNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public string Gender { get; set; }

      
        public string Address { get; set; }

        public bool IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public string Role { get; set; }

        public int? Otp { get; set; }
       
        public  List<Sale> sale { get; set; }
        public List<Purchase> purchase { get; set; }

    }
}
