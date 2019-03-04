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
    public class TaxRepository : ITaxRepository
    {

        DatabaseContext db = new DatabaseContext();

        public IUnitOfWork _unitofwork;
        public TaxRepository(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;

        }
        public void Delete(TaxType taxtype)
        {
            throw new NotImplementedException();
        }

        public void Edit(TaxType taxtype)
        {
            _unitofwork.GetRepository<TaxType>().Edit(taxtype);
        }

        public IEnumerable<TaxType> GetAll()
        {
            return _unitofwork.GetRepository<TaxType>().GetAll().Where(a=>a.IsDelete==false);
        }

        public TaxType GetById(int id)
        {
            return _unitofwork.GetRepository<TaxType>().GetById(id);
        }

        public void Insert(TaxType taxtype)
        {
            _unitofwork.GetRepository<TaxType>().Insert(taxtype);
        }

        public bool Deletetax(TaxType taxtype)

        {
            TaxType tax = db.taxtype.Where(x => x.TaxId == taxtype.TaxId).SingleOrDefault();
            tax.IsDelete = true;
            db.Entry(tax).State = EntityState.Modified;
            db.SaveChanges();
            if (tax.IsDelete == true)
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
