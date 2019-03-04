using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_DATA.Core
{
    public class TaxType
    {
        [Key]
        public int TaxId { get; set; }
        public int TaxRate { get; set; }

        public bool IsDelete { get; set; }
        public List<Sale> sale { get; set; }
        public List<Purchase> purchase { get; set; }

    }
}
