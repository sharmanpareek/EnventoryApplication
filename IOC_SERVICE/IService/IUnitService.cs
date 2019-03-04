using IOC_DATA.Core;
using IOC_SERVICE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IOC_SERVICE.IService
{
    public interface IUnitService
    {
        UnitTypeModel GetById(int id);

        IEnumerable<UnitTypeModel> GetAll();

        void Edit(UnitTypeModel unittypemodel);

        void Insert(UnitTypeModel unittypemodel);

        void Delete(UnitTypeModel unittypemodel);

        bool DeleteUnit(UnitTypeModel unitmodel);

    }
    
}

