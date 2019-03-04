using IOC_SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOC_SERVICE.Data;
using IOC_REPOSITORY.IRepository;
using AutoMapper;
using IOC_DATA.Core;

namespace IOC_SERVICE.Service
{
  public  class TaxService : ITaxService
    {
        ITaxRepository taxRepository;

        public TaxService(ITaxRepository _taxRepository)
        {
            taxRepository = _taxRepository;
        }
        public void Delete(TaxTypeModel taxtypemodel)
        {
            throw new NotImplementedException();
        }

        public bool Deletetax(TaxTypeModel taxtypemodel)
        {
            Mapper.Initialize(map => { map.CreateMap<TaxTypeModel, TaxType>(); });
            var taxData = Mapper.Map<TaxType>(taxtypemodel);
            return taxRepository.Deletetax(taxData);
        }

        public void Edit(TaxTypeModel taxtypemodel)
        {
            Mapper.Initialize(map => { map.CreateMap<TaxTypeModel, TaxType>(); });
            var taxData = Mapper.Map<TaxType>(taxtypemodel);
            taxRepository.Edit(taxData);
        }

        public IEnumerable<TaxTypeModel> GetAll()
        {
            var Tax = taxRepository.GetAll();
            Mapper.Initialize(map => { map.CreateMap<TaxType, TaxTypeModel>(); });
            var taxData = Mapper.Map<IEnumerable<TaxType>, IEnumerable<TaxTypeModel>>(Tax);
            return taxData;
        }

        public TaxTypeModel GetById(int id)
        {
            var tax = taxRepository.GetById(id);
            Mapper.Initialize(cfg => { cfg.CreateMap<TaxType, TaxTypeModel>(); });

            var taxModel = Mapper.Map<TaxTypeModel>(tax);


            return taxModel;
        }

        public void Insert(TaxTypeModel taxtypemodel)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<TaxTypeModel, TaxType>(); });

            var tax = Mapper.Map<TaxType>(taxtypemodel);
            taxRepository.Insert(tax);
        }
    }
}
