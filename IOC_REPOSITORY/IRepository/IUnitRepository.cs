using IOC_DATA.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_REPOSITORY.IRepository
{
    public interface IUnitRepository
    {
        UnitType GetById(int id);

        IEnumerable<UnitType> GetAll();

        void Edit(UnitType unittype);

        void Insert(UnitType unittype);

        void Delete(UnitType unittype);

        bool DeleteUnit(UnitType unittype);
    }
    
}
