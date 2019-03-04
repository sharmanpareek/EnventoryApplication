using IOC_SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOC_SERVICE.Data;
using IOC_REPOSITORY.IRepository;
using AutoMapper;
using IOC_DATA.Core;

namespace IOC_SERVICE.Service
{
   public class CategoryService : ICategoryService
    {
        ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }
        public void Delete(CategoryModel categorymodel)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCategory(CategoryModel categorymodel)
        {
            Mapper.Initialize(map => { map.CreateMap<CategoryModel, Category>(); });
            var categoryData = Mapper.Map<Category>(categorymodel);
            return categoryRepository.DeleteCategory(categoryData);
        }

        public void Edit(CategoryModel categorymodel)
        {
            Mapper.Initialize(map => { map.CreateMap<CategoryModel, Category>(); });
            var categoryData = Mapper.Map<Category>(categorymodel);
            categoryRepository.Edit(categoryData);
        }

        public IEnumerable<CategoryModel> GetAll()
        {
            var categoryData = categoryRepository.GetAll();
            Mapper.Initialize(map => { map.CreateMap<Category, CategoryModel>(); });
            var category = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(categoryData);
            return category;
        }

        public CategoryModel GetById(int id)
        {
            var categoryData = categoryRepository.GetById(id);
            Mapper.Initialize(map => { map.CreateMap<Category, CategoryModel>(); });
            var category = Mapper.Map<Category, CategoryModel>(categoryData);
            return category;
        }

        public void Insert(CategoryModel categorymodel)
        {
            Mapper.Initialize(map => { map.CreateMap<CategoryModel, Category>(); });
            var category = Mapper.Map<Category>(categorymodel);
            categoryRepository.Insert(category);
        }
    }
}
