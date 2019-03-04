using IOC_DATA.Core;
using IOC_SERVICE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE.IService
{
    public interface IPartyService
    {
        PartyTypeModel GetById(int id);

        IEnumerable<PartyTypeModel> GetAll();

        void Edit(PartyTypeModel partytypemodel);

        void Insert(PartyTypeModel partytypemodel);

        void Delete(PartyTypeModel partytypemodel);

        bool DeleteParty(PartyTypeModel partytypemodel);
    }
}

