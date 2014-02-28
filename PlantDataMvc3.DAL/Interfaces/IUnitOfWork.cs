using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMvc3.DAL.Entities;

namespace PlantDataMvc3.DAL.Interfaces
{
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

        void Commit();
    }
}
