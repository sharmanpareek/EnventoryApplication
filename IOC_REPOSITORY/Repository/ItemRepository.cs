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
    public class ItemRepository : IItemRepository
    {
      private  DatabaseContext db = new DatabaseContext();

        public IUnitOfWork _unitofwork;
        public ItemRepository(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;

        }

        public void Delete(ItemType itemtype)
        {
            _unitofwork.GetRepository<ItemType>().Delete(itemtype);
        }

        public void Edit(ItemType itemtype)
        {
            _unitofwork.GetRepository<ItemType>().Edit(itemtype);
        }

        public IEnumerable<ItemType> GetAll()
        {
           return _unitofwork.GetRepository<ItemType>().GetAll().Where(a=>a.IsDeleted==false);
        }

        public ItemType GetById(int id)
        {
          return  _unitofwork.GetRepository<ItemType>().GetById(id);
        }

        public void Insert(ItemType itemtype)
        {
            _unitofwork.GetRepository<ItemType>().Insert(itemtype);
        }

        public bool DeleteItem(ItemType itemtype)
        {
            ItemType item = db.itemtype.Where(a => a.ItemId == itemtype.ItemId).SingleOrDefault();
            item.IsDeleted = true;
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            if (item.IsDeleted==true)
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
