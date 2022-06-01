using Framework.Domain.EF;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.Models;
using System;

namespace PlantDataMVC.Entities.Interfaces
{

    public interface IPlantDataDbContext : IDbContext, IDisposable
    {
        DbSet<Genus> Genus { get; set; } // Genus
        DbSet<JournalEntry> JournalEntries { get; set; } // JournalEntry
        DbSet<JournalEntryType> JournalEntryTypes { get; set; } // JournalEntryType
        DbSet<PlantStock> PlantStocks { get; set; } // PlantStock
        DbSet<PriceListType> PriceListTypes { get; set; } // PriceListType
        DbSet<ProductPrice> ProductPrices { get; set; } // ProductPrice
        DbSet<ProductType> ProductTypes { get; set; } // ProductType
        DbSet<SaleEvent> SaleEvents { get; set; } // SaleEvent
        DbSet<SeedBatch> SeedBatches { get; set; } // SeedBatch
        DbSet<SeedTray> SeedTrays { get; set; } // SeedTray
        DbSet<Site> Sites { get; set; } // Site
        DbSet<Species> Species { get; set; } // Species


    }

}
