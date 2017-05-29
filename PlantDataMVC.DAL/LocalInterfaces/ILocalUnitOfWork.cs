using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMvc3.DAL.LocalInterfaces
{
    public interface ILocalUnitOfWork : IDisposable
    {
        ILocalGenusRepository<ILocalGenus> GenusRepository { get; }
        ILocalJournalEntryRepository<ILocalJournalEntry>  JournalEntryRepository { get; }
        ILocalJournalEntryTypeRepository<ILocalJournalEntryType> JournalEntryTypeRepository { get; }
        ILocalPlantStockRepository<ILocalPlantStock> PlantStockRepository { get; }
        ILocalProductTypeRepository<ILocalProductType> ProductTypeRepository { get; }
        ILocalSeedBatchRepository<ILocalSeedBatch> SeedBatchRepository { get; }
        ILocalSeedTrayRepository<ILocalSeedTray> SeedTrayRepository { get; }
        ILocalSpeciesRepository<ILocalSpecies> SpeciesRepository { get; }
        ILocalSiteRepository<ILocalSite> SiteRepository { get; }

        void Commit();
    }
}
