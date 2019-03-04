using IOC_REPOSITORY.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOC_DATA.Core;
using IOC_DATA;
using IOC_DATA.Infrastructure;
using System.Data.Entity;

namespace IOC_REPOSITORY.Repository
{
    public class UnitRepository : IUnitRepository
    {
        DatabaseContext db = new DatabaseContext();

        public IUnitOfWork _unitofwork;
        public UnitRepository(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;

        }
        void IUnitRepository.Delete(UnitType unittype)
        {
            throw new NotImplementedException();
        }

        void IUnitRepository.Edit(UnitType unittype)
        {
            _unitofwork.GetRepository<UnitType>().Edit(unittype);
        }

        IEnumerable<UnitType> IUnitRepository.GetAll()
        {
            return _unitofwork.GetRepository<UnitType>().GetAll().Where(a=>a.IsDelete==false);
        }

        UnitType IUnitRepository.GetById(int id)
        {
            return _unitofwork.GetRepository<UnitType>().GetById(id);
        }

        void IUnitRepository.Insert(UnitType unittype)
        {
            _unitofwork.GetRepository<UnitType>().Insert(unittype);
        }

        public bool DeleteUnit(UnitType unittype)
        {
            UnitType unittypes = db.unittype.Where(x => x.UnitId == unittype.UnitId).SingleOrDefault();
            unittypes.IsDelete = true;
            db.Entry(unittypes).State = EntityState.Modified;
            db.SaveChanges();
            if(unittypes.IsDelete==true)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
