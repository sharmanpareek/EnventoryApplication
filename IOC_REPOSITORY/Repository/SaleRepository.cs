using IOC_REPOSITORY.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOC_DATA.Core;
using IOC_DATA;
using IOC_DATA.Infrastructure;
using System.Data;
using System.Data.Entity.Infrastructure;

namespace IOC_REPOSITORY.Repository
{
    class Inv
    {
        public int Invc { get; set; }
    }
    public class SaleRepository : ISaleRepository
    {
        DatabaseContext db = new DatabaseContext();

        public IUnitOfWork _unitofwork;
        public SaleRepository(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;

        }
        public void Delete(Sale sale)
        {
            throw new NotImplementedException();
        }

        public void Edit(Sale sale)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sale> GetAll()
        {
            return _unitofwork.GetRepository<Sale>().GetAll();
        }

        public Sale GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Sale Insert(Sale sale)
        {
            _unitofwork.GetRepository<Sale>().Insert(sale);
            return sale;
        }

        public int ExecuteSp()
        {
            //int result = db.Database.ExecuteSqlCommand("GeneratedInvoiceNumber");
            db.Database.Initialize(force: false);
            var cmd = db.Database.Connection.CreateCommand();
            cmd.CommandText = "GeneratedInvoiceNumber";
            cmd.CommandType = CommandType.StoredProcedure;
            db.Database.Connection.Open();
            var reader = cmd.ExecuteReader();
            int result=((IObjectContextAdapter)db).ObjectContext.Translate<int>(reader).FirstOrDefault();
            return result;
           
        }
    }
}
