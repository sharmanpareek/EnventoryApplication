using IOC_DATA.Core;
using IOC_SERVICE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE.IService
{
   public interface IItemService
    {
        ItemTypeModel GetById(int id);

        IEnumerable<ItemTypeModel> GetAll();

        void Edit(ItemTypeModel itemtypemodel);

        void Insert(ItemTypeModel itemtypemodel);

        void Delete(ItemTypeModel itemtypemodel);

        bool DeleteItem(ItemTypeModel itemtypemodel);

        List<SaleDetailViewModel> GetReport();
    }
}
