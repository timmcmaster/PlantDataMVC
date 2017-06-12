using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.DAL.Entities;

namespace PlantDataMVC.DAL.Interfaces
{
    /// <summary>
    /// This is the base interface for the unit of work object that is exposed from the DAL to the business layer.
    /// If a new repository type is added to the model, an interface get property should be added here.
    /// </summary>
    public interface IUnitOfWork: IDisposable
    {
        IGenusRepository GenusRepository { get; }
        IJournalEntryRepository JournalEntryRepository { get; }
        IJournalEntryTypeRepository JournalEntryTypeRepository { get; }
        IPlantStockRepository PlantStockRepository { get; }
        IProductTypeRepository ProductTypeRepository { get; }
        ISeedBatchRepository SeedBatchRepository { get; }
        ISeedTrayRepository SeedTrayRepository { get; }
        ISpeciesRepository SpeciesRepository { get; }
        ISiteRepository SiteRepository { get; }

        //IGenusRepository<IGenus> GenusRepository { get; }
        //IJournalEntryRepository<IJournalEntry> JournalEntryRepository { get; }
        //IJournalEntryTypeRepository<IJournalEntryType> JournalEntryTypeRepository { get; }
        //IPlantStockRepository<IPlantStock> PlantStockRepository { get; }
        //IProductTypeRepository<IProductType> ProductTypeRepository { get; }
        //ISeedBatchRepository<ISeedBatch> SeedBatchRepository { get; }
        //ISeedTrayRepository<ISeedTray> SeedTrayRepository { get; }
        //ISpeciesRepository<ISpecies> SpeciesRepository { get; }
        //ISiteRepository<ISite> SiteRepository { get; }

        /// <summary>
        /// Commit the transaction to the repository collection.
        /// </summary>
        void Commit();
    }
}
