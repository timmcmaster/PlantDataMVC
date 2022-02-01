using Framework.Domain.EF;
using PlantDataMVC.Entities.Configuration;
using PlantDataMVC.Entities.Interfaces;
using PlantDataMVC.Entities.Models;

using System.Data.Entity;

namespace PlantDataMVC.Entities.Context
{


    public class PricingDbContext : DbContext, IPricingDbContext
    {
        public IDbSet<PriceListType> PriceListTypes { get; set; } // PriceListType
        public IDbSet<ProductPrice> ProductPrices { get; set; } // ProductPrice
        public IDbSet<ProductType> ProductTypes { get; set; } // ProductType

        static PricingDbContext()
        {
            // Disable CodeFirst migrations 
            Database.SetInitializer<PricingDbContext>(null);
        }

        //public PricingDbContext() 
        //    : base("Name=PlantDataDbContext")
        //{
        //}

        public PricingDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public PricingDbContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PriceListTypeConfiguration());
            modelBuilder.Configurations.Add(new ProductPriceConfiguration());
            modelBuilder.Configurations.Add(new ProductTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
