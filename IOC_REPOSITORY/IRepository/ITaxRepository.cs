using IOC_DATA.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_REPOSITORY.IRepository
{
    public interface ITaxRepository
    {
        TaxType GetById(int id);

        IEnumerable<TaxType> GetAll();

        void Edit(TaxType taxtype);

        void Insert(TaxType taxtype);

        void Delete(TaxType taxtype);
        bool Deletetax(TaxType taxtype);
    }
}
