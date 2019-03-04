using IOC_DATA.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_REPOSITORY.IRepository
{
    public interface IPartyRepository
    {
        PartyType GetById(int id);

        IEnumerable<PartyType> GetAll();

        void Edit(PartyType partytype);

        void Insert(PartyType partytype);

        void Delete(PartyType partytype);
        bool DeleteParty(PartyType partytype);
    }
}

