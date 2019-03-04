using IOC_DATA.Core;
using IOC_SERVICE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE.IService
{
  public  interface ISaleService
    {
        SaleModel GetById(int id);

        IEnumerable<SaleModel> GetAll();

        void Edit(SaleModel salemodel);

        void Insert(SaleModel salemodel);

        void Delete(SaleModel salemodel);

        int ExecuteSp();
        SaleModel SaveSaleDetails(SaleViewModel saleviewmodel);

        List<SaleViewModel> SaleDetail(int userId);

       SaleViewModel SaleBillDetail(int saleid);

        List<SaleViewModel> GetSaleDetail();


    }
}
