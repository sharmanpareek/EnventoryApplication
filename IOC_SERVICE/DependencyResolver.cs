using IOC_DATA;
using IOC_DATA.Infrastructure;
using IOC_REPOSITORY.IRepository;
using IOC_REPOSITORY.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_SERVICE
{
   public class DependencyResolver:NinjectModule
    {
        public override void Load()
        {
            Bind<IDatabasecontext>().To<DatabaseContext>().InThreadScope();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IItemRepository>().To<ItemRepository>();
            Bind<IUnitRepository>().To<UnitRepository>();
            Bind<IPartyRepository>().To<PartyRepository>();
            Bind<ITaxRepository>().To<TaxRepository>();
            Bind<ISaleDetailRepository>().To<SaleDetailRepository>();
            Bind<ISaleRepository>().To<SaleRepository>();
            Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<IPurchaseRepository>().To<PurchaseRepository>();
            Bind<IPurchaseDetailRepository>().To<PurchaseDetailRepository>();
        }
        
    }
}
