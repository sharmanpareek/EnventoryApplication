using IOC_REPOSITORY.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOC_SERVICE.Data;
using IOC_SERVICE.IService;
using AutoMapper;
using IOC_DATA.Core;

namespace IOC_SERVICE.Service
{
   public class UnitService : IUnitService
    {
        IUnitRepository unitRepository;

        public UnitService(IUnitRepository _unitRepository)
        {
            unitRepository = _unitRepository;
        }
        public void Delete(UnitTypeModel unittypemodel)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUnit(UnitTypeModel unitmodel)
        {
            Mapper.Initialize(map => { map.CreateMap<UnitTypeModel, UnitType>(); });
            var unitData = Mapper.Map<UnitType>(unitmodel);
            return unitRepository.DeleteUnit(unitData);
        }

        public void Edit(UnitTypeModel unittypemodel)
        {
            Mapper.Initialize(map => { map.CreateMap<UnitTypeModel, UnitType>(); });
            var unitData = Mapper.Map<UnitType>(unittypemodel);
            unitRepository.Edit(unitData);
        }

        public IEnumerable<UnitTypeModel> GetAll()
        {
            var unitData = unitRepository.GetAll();
            Mapper.Initialize(map => { map.CreateMap<UnitType, UnitTypeModel>(); });
            var unit = Mapper.Map<IEnumerable<UnitType>, IEnumerable<UnitTypeModel>>(unitData);
            return unit;
        }

        public UnitTypeModel GetById(int id)
        {
            var unit = unitRepository.GetById(id);
            Mapper.Initialize(map => { map.CreateMap<UnitType, UnitTypeModel>(); });
            var unitData = Mapper.Map<UnitType, UnitTypeModel>(unit);
            return unitData;
        }

        public void Insert(UnitTypeModel unittypemodel)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<UnitTypeModel, UnitType>(); });

            var unit = Mapper.Map<UnitType>(unittypemodel);
            unitRepository.Insert(unit);
        }
    }
}
