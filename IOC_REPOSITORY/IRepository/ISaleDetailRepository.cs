using IOC_DATA.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_REPOSITORY.IRepository
{
    public interface ISaleDetailRepository
    {
        SaleDetail GetById(int id);

        IEnumerable<SaleDetail> GetAll();

        void Edit(SaleDetail saledetail);

        void Insert(SaleDetail saledetail);

        void Delete(SaleDetail saledetail);
    }
}
