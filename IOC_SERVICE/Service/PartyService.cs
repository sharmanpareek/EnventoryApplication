using IOC_REPOSITORY.IRepository;
using IOC_SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOC_SERVICE.Data;
using AutoMapper;
using IOC_DATA.Core;

namespace IOC_SERVICE.Service
{
    public class PartyService : IPartyService
    {
        IPartyRepository partyRepository;

        public PartyService(IPartyRepository _partyRepository)
        {
            partyRepository = _partyRepository;
        }
        public void Delete(PartyTypeModel partytypemodel)
        {
            Mapper.Initialize(map => { map.CreateMap<PartyTypeModel, PartyType>(); });
            var partyData = Mapper.Map<PartyType>(partytypemodel);
            // partyData.IsDelete = true;
            partyRepository.Delete(partyData);
        }

        public void Edit(PartyTypeModel partytypemodel)
        {
            Mapper.Initialize(map => { map.CreateMap<PartyTypeModel, PartyType>(); });
            var partyData = Mapper.Map<PartyType>(partytypemodel);
            partyRepository.Edit(partyData);
        }

        public IEnumerable<PartyTypeModel> GetAll()
        {
            var party = partyRepository.GetAll();
            Mapper.Initialize(map => { map.CreateMap<PartyType, PartyTypeModel>(); });
            var partyData = Mapper.Map<IEnumerable<PartyType>, IEnumerable<PartyTypeModel>>(party);
            return partyData;
        }

        public PartyTypeModel GetById(int id)
        {
            var prty = partyRepository.GetById(id);
            Mapper.Initialize(map => { map.CreateMap<PartyType, PartyTypeModel>(); });
            var partyData = Mapper.Map<PartyType, PartyTypeModel>(prty);
            return partyData;

        }

        public void Insert(PartyTypeModel partytypemodel)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<PartyTypeModel, PartyType>(); });

            var party = Mapper.Map<PartyType>(partytypemodel);

            //User user = new User();

            partyRepository.Insert(party);
        }
        public bool DeleteParty(PartyTypeModel partytypemodel)
        {
            Mapper.Initialize(map => { map.CreateMap<PartyTypeModel, PartyType>(); });
            var partyData = Mapper.Map<PartyType>(partytypemodel);
            return partyRepository.DeleteParty(partyData);
            
        }
    }
}
