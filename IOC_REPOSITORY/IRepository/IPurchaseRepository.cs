using IOC_DATA.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_REPOSITORY.IRepository
{
   public interface IPurchaseRepository
    {
        Purchase GetById(int id);

        IEnumerable<Purchase> GetAll();

        void Edit(Purchase purchase);

        Purchase Insert(Purchase purchase);

        void Delete(Purchase purchase);
        bool CancelBill(Purchase purchase);
    }
}
