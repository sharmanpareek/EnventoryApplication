using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE.Data
{
  public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Fill Category Name")]
        [StringLength(100, ErrorMessage = "Name must not exceed {1} character")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string CategoryName { get; set; }
        public bool IsDelete { get; set; }
        public List<ItemTypeModel> itemtypemodel { get; set; }

    }
}
