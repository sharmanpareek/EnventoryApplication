using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_DATA.Infrastructure
{
   public interface IGenericRepository<TEntity> where TEntity : class
    {

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Edit(TEntity entity);

        void Insert(TEntity entity);

        void Delete(TEntity entity);

        
    }

}
