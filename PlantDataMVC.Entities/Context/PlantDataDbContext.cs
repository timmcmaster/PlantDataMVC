// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.7
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning


namespace PlantDataMVC.Entities.Context
{
    using PlantDataMVC.Entities.Configuration;
    using PlantDataMVC.Entities.Interfaces;
    using PlantDataMVC.Entities.Models;


    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.31.1.0")]
    public partial class PlantDataDbContext : Framework.DAL.EF.DataContext, IPlantDataDbContext
    {
        public System.Data.Entity.DbSet<Genus> Genus { get; set; } // Genus
        public System.Data.Entity.DbSet<JournalEntry> JournalEntries { get; set; } // JournalEntry
        public System.Data.Entity.DbSet<JournalEntryType> JournalEntryTypes { get; set; } // JournalEntryType
        public System.Data.Entity.DbSet<PlantStock> PlantStocks { get; set; } // PlantStock
        public System.Data.Entity.DbSet<PriceListType> PriceListTypes { get; set; } // PriceListType
        public System.Data.Entity.DbSet<ProductPrice> ProductPrices { get; set; } // ProductPrice
        public System.Data.Entity.DbSet<ProductType> ProductTypes { get; set; } // ProductType
        public System.Data.Entity.DbSet<SeedBatch> SeedBatches { get; set; } // SeedBatch
        public System.Data.Entity.DbSet<SeedTray> SeedTrays { get; set; } // SeedTray
        public System.Data.Entity.DbSet<Site> Sites { get; set; } // Site
        public System.Data.Entity.DbSet<Species> Species { get; set; } // Species

        static PlantDataDbContext()
        {
            System.Data.Entity.Database.SetInitializer<PlantDataDbContext>(null);
        }

        public PlantDataDbContext()
            : base("Name=PlantDataDbContext")
        {
            InitializePartial();
        }

        public PlantDataDbContext(string connectionString)
            : base(connectionString)
        {
            InitializePartial();
        }

        public PlantDataDbContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
            InitializePartial();
        }

        public PlantDataDbContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            InitializePartial();
        }

        public PlantDataDbContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
            InitializePartial();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new GenusConfiguration());
            modelBuilder.Configurations.Add(new JournalEntryConfiguration());
            modelBuilder.Configurations.Add(new JournalEntryTypeConfiguration());
            modelBuilder.Configurations.Add(new PlantStockConfiguration());
            modelBuilder.Configurations.Add(new PriceListTypeConfiguration());
            modelBuilder.Configurations.Add(new ProductPriceConfiguration());
            modelBuilder.Configurations.Add(new ProductTypeConfiguration());
            modelBuilder.Configurations.Add(new SeedBatchConfiguration());
            modelBuilder.Configurations.Add(new SeedTrayConfiguration());
            modelBuilder.Configurations.Add(new SiteConfiguration());
            modelBuilder.Configurations.Add(new SpeciesConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new GenusConfiguration(schema));
            modelBuilder.Configurations.Add(new JournalEntryConfiguration(schema));
            modelBuilder.Configurations.Add(new JournalEntryTypeConfiguration(schema));
            modelBuilder.Configurations.Add(new PlantStockConfiguration(schema));
            modelBuilder.Configurations.Add(new PriceListTypeConfiguration(schema));
            modelBuilder.Configurations.Add(new ProductPriceConfiguration(schema));
            modelBuilder.Configurations.Add(new ProductTypeConfiguration(schema));
            modelBuilder.Configurations.Add(new SeedBatchConfiguration(schema));
            modelBuilder.Configurations.Add(new SeedTrayConfiguration(schema));
            modelBuilder.Configurations.Add(new SiteConfiguration(schema));
            modelBuilder.Configurations.Add(new SpeciesConfiguration(schema));
            return modelBuilder;
        }

        partial void InitializePartial();
        partial void OnModelCreatingPartial(System.Data.Entity.DbModelBuilder modelBuilder);
    }
}
// </auto-generated>
