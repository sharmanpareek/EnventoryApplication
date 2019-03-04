using IOC_REPOSITORY.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOC_DATA.Core;
using IOC_DATA;
using IOC_DATA.Infrastructure;

namespace IOC_REPOSITORY.Repository
{
    public class PurchaseDetailRepository : IPurchaseDetailRepository
    {
        DatabaseContext db = new DatabaseContext();

        public IUnitOfWork _unitofwork;
        public PurchaseDetailRepository(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;

        }
        public void Delete(PurchaseDetail purchasedetail)
        {
            throw new NotImplementedException();
        }

        public void Edit(PurchaseDetail purchasedetail)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PurchaseDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public PurchaseDetail GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(PurchaseDetail purchasedetail)
        {
            _unitofwork.GetRepository<PurchaseDetail>().Insert(purchasedetail);
        }
    }
}
