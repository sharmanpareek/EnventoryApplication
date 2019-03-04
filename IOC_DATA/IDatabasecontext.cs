using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_DATA
{
  public interface IDatabasecontext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        void dispose();
        int SaveChanges();
    }
}
