using IOC_SERVICE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE.IService
{
  public  interface ICategoryService
    {
        CategoryModel GetById(int id);

        IEnumerable<CategoryModel> GetAll();

        void Edit(CategoryModel categorymodel);

        void Insert(CategoryModel categorymodel);

        void Delete(CategoryModel categorymodel);

        bool DeleteCategory(CategoryModel categorymodel);
    }
}

