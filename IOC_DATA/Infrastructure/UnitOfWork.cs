using IOC_DATA;
using IOC_DATA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_DATA.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public DatabaseContext _dbcontext;
        private IDictionary<Type, object> repositories;
        public UnitOfWork(DatabaseContext context)
        {
            _dbcontext = context;
            repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
             {
                return repositories[typeof(T)] as IGenericRepository<T>;
            }
            IGenericRepository<T> repo = new GenericRepository<T>(_dbcontext);
            repositories.Add(typeof(T), repo);
            return repo;
        }




        //public IGenericRepository<T> Repository<T>() where T : class
        //{
        //    if (repositories.Keys.Contains(typeof(T)) == true)
        //    {
        //        return repositories[typeof(T)] as IGenericRepository<T>;
        //    }
        //    IGenericRepository<T> repo = new GenericRepository<T>(_dbcontext);
        //    repositories.Add(typeof(T), repo);
        //    return repo;
        //}







        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbcontext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }

      
    }







}


