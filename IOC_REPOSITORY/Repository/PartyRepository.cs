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
    public class PartyRepository : IPartyRepository
    {
       private DatabaseContext db = new DatabaseContext();

        public IUnitOfWork _unitofwork;
        public PartyRepository(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;

        }
        public void Delete(PartyType partytype)
        {
            _unitofwork.GetRepository<PartyType>().Delete(partytype);
        }

        public void Edit(PartyType partytype)
        {
            _unitofwork.GetRepository<PartyType>().Edit(partytype);
        }

        public IEnumerable<PartyType> GetAll()
        {
            return _unitofwork.GetRepository<PartyType>().GetAll().Where(x=>x.IsDelete == false);
        }

        public PartyType GetById(int id)
        {
            return _unitofwork.GetRepository<PartyType>().GetById(id);
        }

        public void Insert(PartyType partytype)
        {
            _unitofwork.GetRepository<PartyType>().Insert(partytype);
        }

     

        public bool DeleteParty(PartyType partytype)
        {
                PartyType party = db.partytype.Where(x => x.PartyId == partytype.PartyId).SingleOrDefault();
                party.IsDelete = true;
                db.Entry(party).State = EntityState.Modified;
                db.SaveChanges();

            if (party.IsDelete == true)
                return true;
            else
                return false;
            
        }
    }
}
