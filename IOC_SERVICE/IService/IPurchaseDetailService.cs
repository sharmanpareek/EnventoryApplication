using IOC_SERVICE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE.IService
{
   public interface IPurchaseDetailService
    {
        PurchaseDetailModel GetById(int id);

        IEnumerable<PurchaseDetailModel> GetAll();

        void Edit(PurchaseDetailModel purchasedetailmodel);

        void Insert(PurchaseDetailModel purchasedetailmodel);

        void Delete(PurchaseDetailModel purchasedetailmodel);
    }
}
