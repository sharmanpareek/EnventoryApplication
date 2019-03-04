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
   public class CategoryRepository : ICategoryRepository
    {
        DatabaseContext db = new DatabaseContext();

        public IUnitOfWork _unitofwork;
        public CategoryRepository(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;

        }

        public void Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public void Edit(Category category)
        {
            _unitofwork.GetRepository<Category>().Edit(category);
        }

        public IEnumerable<Category> GetAll()
        {
           return  _unitofwork.GetRepository<Category>().GetAll().Where(a=>a.IsDelete==false);
        }

        public Category GetById(int id)
        {
            return _unitofwork.GetRepository<Category>().GetById(id);
        }

        public void Insert(Category category)
        {
            _unitofwork.GetRepository<Category>().Insert(category);
        }

        public bool DeleteCategory(Category category)
        {
            Category categories = db.category.Where(a => a.CategoryId == category.CategoryId).SingleOrDefault();
            categories.IsDelete = true;
            db.Entry(categories).State = EntityState.Modified;
            db.SaveChanges();
            if (categories.IsDelete== true)
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
