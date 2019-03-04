using IOC_DATA.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_DATA
{
    public class DatabaseContext : DbContext, IDatabasecontext
    {
        public DatabaseContext() : base("name=Connection")
        {

        }


        public DbSet<User> user { get; set; }
        public DbSet<ItemType> itemtype { get; set; }
        public DbSet<PartyType> partytype { get; set; }
        public DbSet<Sale> sale { get; set; }
        public DbSet<SaleDetail> saledetail {get;set;}
        public DbSet<TaxType> taxtype { get; set; }
        public DbSet<UnitType> unittype { get; set; }

        public DbSet<Category> category { get; set; }
        public DbSet<Purchase> purchase { get; set; }
        public DbSet<PurchaseDetail> purchasedetail { get; set; }


        public void dispose()
        {
           
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<UnitType>().ToTable("UnitTable");
            modelBuilder.Entity<TaxType>().ToTable("TaxTable");
            modelBuilder.Entity<SaleDetail>().ToTable("SaleDetail");
            modelBuilder.Entity<Sale>().ToTable("Sale");
            modelBuilder.Entity<PartyType>().ToTable("PartyTypeTable");
            modelBuilder.Entity<ItemType>().ToTable("ItemTypeTable");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Purchase>().ToTable("Purchase");
            modelBuilder.Entity<PurchaseDetail>().ToTable("PurchaseDetail");


        }

        DbSet<TEntity> IDatabasecontext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

      

      
    }
}
