using PlantDataMVC.Entities.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System;
using Framework.Domain.EF;

namespace PlantDataMVC.Entities.Interfaces
{

    public interface IPlantDataDbContext : IDbContext, IDisposable
    {
        IDbSet<Genus> Genus { get; set; } // Genus
        IDbSet<JournalEntry> JournalEntries { get; set; } // JournalEntry
        IDbSet<JournalEntryType> JournalEntryTypes { get; set; } // JournalEntryType
        IDbSet<PlantStock> PlantStocks { get; set; } // PlantStock
        IDbSet<PriceListType> PriceListTypes { get; set; } // PriceListType
        IDbSet<ProductPrice> ProductPrices { get; set; } // ProductPrice
        IDbSet<ProductType> ProductTypes { get; set; } // ProductType
        IDbSet<SeedBatch> SeedBatches { get; set; } // SeedBatch
        IDbSet<SeedTray> SeedTrays { get; set; } // SeedTray
        IDbSet<Site> Sites { get; set; } // Site
        IDbSet<Species> Species { get; set; } // Species


    }

}
