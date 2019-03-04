using IOC_DATA.Core;
using IOC_SERVICE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE.IService
{
  public  interface ISaleDetailService
    {
        SaleDetailModel GetById(int id);

        IEnumerable<SaleDetailModel> GetAll();

        void Edit(SaleDetailModel saledetailmodel);

        void Insert(SaleDetailModel saledetailmodel);

        void Delete(SaleDetailModel saledetailmodel);
    }
}
