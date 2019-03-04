using IOC_SERVICE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE.IService
{
    public interface IPurchaseService
    {
        PurchaseModel GetById(int id);

        IEnumerable<PurchaseModel> GetAll();

        void Edit(PurchaseModel purchasemodel);

        void Insert(PurchaseModel purchasemodel);

        void Delete(PurchaseModel purchasemodel);
        PurchaseModel savePurchaseDetails(PurchaseViewModel purchaseviewmodel);

        List<PurchaseViewModel> purchaseViewDetail(int userId);
        List<PurchaseViewModel> GetpurchaseViewDetail();
        PurchaseViewModel billDetail(int purchaseid);
        bool cancelbill(PurchaseModel purchasemodel);
    }
}
