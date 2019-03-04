using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_DATA.Core
{
    public class PartyType
    {
        [Key]
        public int PartyId { get; set; }
        public string PartyName { get; set; }
        public string Contact { get; set; }

        public string Address { get; set; }
        public bool IsDelete { get; set; }
        public  List<Sale> sale { get; set; }
        public List<Purchase> purchase { get; set; }


    }
}
