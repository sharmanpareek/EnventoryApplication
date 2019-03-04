using IOC_DATA;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_DATA.Infrastructure
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

         IDbSet<TEntity> _dbSet;
        public DatabaseContext dbContext;
        //private DbContext _context;
       

        public GenericRepository(DatabaseContext _context)
        {
            this.dbContext = _context;
            _dbSet = dbContext.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            if (dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);

            }
            _dbSet.Remove(entity);
            dbContext.SaveChanges();

        }

        public void Edit(TEntity entity)
        {
            _dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();


       


        }

      

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            dbContext.SaveChanges();


        }

      
    }

}
