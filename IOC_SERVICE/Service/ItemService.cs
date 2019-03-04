using IOC_REPOSITORY.IRepository;
using IOC_SERVICE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOC_SERVICE.Data;
using AutoMapper;
using IOC_DATA.Core;
using IOC_DATA;

namespace IOC_SERVICE.Service
{
  public  class ItemService : IItemService
    {
        IItemRepository itemRepository;
        private DatabaseContext db = new DatabaseContext();
        public ItemService(IItemRepository _itemRepository)
        {
            itemRepository = _itemRepository;
        }
        public void Delete(ItemTypeModel itemtypemodel)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItem(ItemTypeModel itemtypemodel)
        {
            Mapper.Initialize(map => { map.CreateMap<ItemTypeModel, ItemType>(); });
            var itemData = Mapper.Map<ItemType>(itemtypemodel);
            return itemRepository.DeleteItem(itemData);
        }

        public void Edit(ItemTypeModel itemtypemodel)
        {
            Mapper.Initialize(map => { map.CreateMap<ItemTypeModel, ItemType>(); });
            var itemData = Mapper.Map<ItemType>(itemtypemodel);
            itemRepository.Edit(itemData);
        }

        public IEnumerable<ItemTypeModel> GetAll()
        {
            var itemData = itemRepository.GetAll();
            Mapper.Initialize(map => { map.CreateMap<ItemType, ItemTypeModel>(); });
            var partyData = Mapper.Map<IEnumerable<ItemType>, IEnumerable<ItemTypeModel>>(itemData);
            return partyData;
        }

        public ItemTypeModel GetById(int id)
        {
            var item = itemRepository.GetById(id);
            Mapper.Initialize(map => { map.CreateMap<ItemType, ItemTypeModel>(); });
            var itemData = Mapper.Map<ItemType, ItemTypeModel>(item);
            return itemData;
        }

        public List<SaleDetailViewModel> GetReport()
        {
            var data = (from itemData in db.itemtype
                        join unittype in db.unittype on itemData.UnitId equals unittype.UnitId
                        select new SaleDetailViewModel
                        {
                            ItemId = itemData.ItemId,
                            ItemName = itemData.ItemName,
                            UnitTypes = unittype.UnitTypes,
                            Quantity = itemData.Quantity

                        }).ToList();
            return data;
        }

        public void Insert(ItemTypeModel itemtypemodel)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<ItemTypeModel, ItemType>(); });

            var item = Mapper.Map<ItemType>(itemtypemodel);
            itemRepository.Insert(item);
        }
    }
}
