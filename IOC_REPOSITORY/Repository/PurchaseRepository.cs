using IOC_REPOSITORY.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOC_DATA.Core;
using IOC_DATA;
using IOC_DATA.Infrastructure;
using System.Data.Entity;

namespace IOC_REPOSITORY.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        DatabaseContext db = new DatabaseContext();

        public IUnitOfWork _unitofwork;
        public PurchaseRepository(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;

        }
        public void Delete(Purchase purchase)
        {
            _unitofwork.GetRepository<Purchase>().Delete(purchase);
        }

        public void Edit(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Purchase> GetAll()
        {
            throw new NotImplementedException();
        }

        public Purchase GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Purchase Insert(Purchase purchase)
        {
            _unitofwork.GetRepository<Purchase>().Insert(purchase);
            return purchase;
        }

        public bool CancelBill(Purchase purchase)
        {
            Purchase purchasedata = db.purchase.Where(x => x.PurchaseId == purchase.PurchaseId).SingleOrDefault();
            purchasedata.IsDeleted = true;
            db.Entry(purchasedata).State = EntityState.Modified;
            db.SaveChanges();
            if(purchasedata.IsDeleted==true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
