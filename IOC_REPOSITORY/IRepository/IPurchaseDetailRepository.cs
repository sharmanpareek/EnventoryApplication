using IOC_DATA.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_REPOSITORY.IRepository
{
   public interface IPurchaseDetailRepository
    {
        PurchaseDetail GetById(int id);

        IEnumerable<PurchaseDetail> GetAll();

        void Edit(PurchaseDetail purchasedetail);

        void Insert(PurchaseDetail purchasedetail);

        void Delete(PurchaseDetail purchasedetail);
    }
}
