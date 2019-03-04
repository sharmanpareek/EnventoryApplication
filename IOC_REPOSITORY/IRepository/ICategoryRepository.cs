using IOC_DATA.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_REPOSITORY.IRepository
{
   public interface ICategoryRepository
    {
        Category GetById(int id);

        IEnumerable<Category> GetAll();

        void Edit(Category category);

        void Insert(Category category);

        void Delete(Category category);

        bool DeleteCategory(Category category);
    }
}
