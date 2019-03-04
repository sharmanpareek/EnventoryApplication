using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE.Data
{
    public class UnitTypeModel
    {
        [Key]
        public int UnitId { get; set; }
        [Required(ErrorMessage ="Fill Unit Name")]
        [StringLength(100, ErrorMessage = "Name must not exceed {1} character")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string UnitTypes { get; set; }
        public bool IsDelete { get; set; }
        public List<ItemTypeModel> itemmodel { get; set; }
    }

}
