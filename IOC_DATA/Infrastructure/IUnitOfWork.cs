using IOC_DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_DATA.Infrastructure
{
    public interface IUnitOfWork 
    {

        IGenericRepository<T> GetRepository<T>() where T : class;
        // IGenericRepository<Model> ModelRepository { get; }
        void Save();

     
    }
}
