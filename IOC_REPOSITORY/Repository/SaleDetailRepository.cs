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
    public class SaleDetailRepository : ISaleDetailRepository
    {
        DatabaseContext db = new DatabaseContext();

        public IUnitOfWork _unitofwork;
        public SaleDetailRepository(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;

        }
        public void Delete(SaleDetail saledetail)
        {
            throw new NotImplementedException();
        }

        public void Edit(SaleDetail saledetail)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SaleDetail> GetAll()
        {
            throw new NotImplementedException();
        }

        public SaleDetail GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(SaleDetail saledetail)
        {
            _unitofwork.GetRepository<SaleDetail>().Insert(saledetail);
        }
    }
}
