using Framework.Domain.EF;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.EntityModels;
using System;

namespace PlantDataMVC.Entities.Interfaces
{

    public interface IPlantDataDbContext : IDbContext, IDisposable
    {
        DbSet<GenusEntityModel> Genus { get; set; } // Genus
        DbSet<JournalEntryEntityModel> JournalEntries { get; set; } // JournalEntry
        DbSet<JournalEntryTypeEntityModel> JournalEntryTypes { get; set; } // JournalEntryType
        DbSet<PlantStockEntityModel> PlantStocks { get; set; } // PlantStock
        DbSet<PriceListTypeEntityModel> PriceListTypes { get; set; } // PriceListType
        DbSet<ProductPriceEntityModel> ProductPrices { get; set; } // ProductPrice
        DbSet<ProductTypeEntityModel> ProductTypes { get; set; } // ProductType
        DbSet<SaleEventEntityModel> SaleEvents { get; set; } // SaleEvent
        DbSet<SeedBatchEntityModel> SeedBatches { get; set; } // SeedBatch
        DbSet<SeedTrayEntityModel> SeedTrays { get; set; } // SeedTray
        DbSet<SiteEntityModel> Sites { get; set; } // Site
        DbSet<SpeciesEntityModel> Species { get; set; } // Species


    }

}
