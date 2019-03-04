using IOC_DATA.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_REPOSITORY.IRepository
{
   public interface IItemRepository
    {
        ItemType GetById(int id);

        IEnumerable<ItemType> GetAll();

        void Edit(ItemType itemtype);

        void Insert(ItemType itemtype);

        void Delete(ItemType itemtype);
        bool DeleteItem(ItemType itemtype);
    }
}
