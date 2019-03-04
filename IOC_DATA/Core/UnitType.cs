using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_DATA.Core
{
    public class UnitType
    {
        [Key]
        public int UnitId { get; set; }
        public string UnitTypes { get; set; }
        public bool IsDelete { get; set; }
        public  List<ItemType>item { get; set; }

    }
}
