using IOC_DATA.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_REPOSITORY.IRepository
{
    public interface ISaleRepository
    {
        Sale GetById(int id);

        IEnumerable<Sale> GetAll();

        void Edit(Sale sale);

        Sale Insert(Sale sale);

        void Delete(Sale sale);

        int ExecuteSp();
    }
}
