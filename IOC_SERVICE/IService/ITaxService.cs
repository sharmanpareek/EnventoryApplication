using IOC_DATA.Core;
using IOC_SERVICE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE.IService
{
   public interface ITaxService
    {
        TaxTypeModel GetById(int id);

        IEnumerable<TaxTypeModel> GetAll();

        void Edit(TaxTypeModel taxtypemodel);

        void Insert(TaxTypeModel taxtypemodel);

        void Delete(TaxTypeModel taxtypemodel);
        bool Deletetax(TaxTypeModel taxtypemodel);
    }
}

