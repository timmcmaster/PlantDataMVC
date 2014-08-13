using System;
using System.Data.Entity;
using PlantDataMvc3.DAL.EF.Entities;
using PlantDataMvc3.DAL.EF.Repositories;
using PlantDataMvc3.DAL.LocalInterfaces;

namespace PlantDataMvc3.DAL.EF.Infrastructure
{
    /// <summary>
    /// Implements the UnitOfWork pattern 
    /// </summary>
    public class EFUnitOfWork : ILocalUnitOfWork, IDisposable
    {
        #region Variables

        private bool _disposed = false;
        protected DbContext _context;

        protected ILocalGenusRepository<Genus> _genusRepository;
        protected ILocalJournalEntryRepository<JournalEntry> _journalEntryRepository;
        protected ILocalJournalEntryTypeRepository<JournalEntryType> _journalEntryTypeRepository;
        protected ILocalPlantStockRepository<PlantStock> _plantStockRepository;
        protected ILocalProductTypeRepository<ProductType> _productTypeRepository;
        protected ILocalSeedBatchRepository<SeedBatch> _seedBatchRepository;
        protected ILocalSeedTrayRepository<SeedTray> _seedTrayRepository;
        protected ILocalSpeciesRepository<Species> _speciesRepository;
        protected ILocalSiteRepository<Site> _siteRepository;

        #endregion Variables

        public EFUnitOfWork()
            : this(new PlantDbContext())
        {
        }

        public EFUnitOfWork(DbContext context)
        {
            this.Context = context;
        }

        #region Properties

        protected DbContext Context
        {
            get { return _context; }
            set { _context = value; }
        }

        public ILocalGenusRepository<ILocalGenus> GenusRepository
        {
            get
            {
                if (_genusRepository == null)
                {
                    _genusRepository = new EFGenusRepository(this.Context);
                }

                return (ILocalGenusRepository<ILocalGenus>) _genusRepository; 
            }
        }

        public ILocalJournalEntryRepository<ILocalJournalEntry> JournalEntryRepository
        {
            get
            {
                if (_journalEntryRepository == null)
                {
                    _journalEntryRepository = new EFJournalEntryRepository(this.Context);
                }

                return (ILocalJournalEntryRepository<ILocalJournalEntry>) _journalEntryRepository;
            }
        }

        public ILocalJournalEntryTypeRepository<ILocalJournalEntryType> JournalEntryTypeRepository
        {
            get
            {
                if (_journalEntryTypeRepository == null)
                {
                    _journalEntryTypeRepository = new EFJournalEntryTypeRepository(this.Context);
                }

                return (ILocalJournalEntryTypeRepository<ILocalJournalEntryType>) _journalEntryTypeRepository;
            }
        }

        public ILocalPlantStockRepository<ILocalPlantStock> PlantStockRepository
        {
            get
            {
                if (_plantStockRepository == null)
                {
                    _plantStockRepository = new EFPlantStockRepository(this.Context);
                }

                return (ILocalPlantStockRepository<ILocalPlantStock>) _plantStockRepository;
            }
        }

        public ILocalProductTypeRepository<ILocalProductType> ProductTypeRepository
        {
            get
            {
                if (_productTypeRepository == null)
                {
                    _productTypeRepository = new EFProductTypeRepository(this.Context);
                }

                return (ILocalProductTypeRepository<ILocalProductType>) _productTypeRepository;
            }
        }

        public ILocalSeedBatchRepository<ILocalSeedBatch> SeedBatchRepository
        {
            get
            {
                if (_seedBatchRepository == null)
                {
                    _seedBatchRepository = new EFSeedBatchRepository(this.Context);
                }

                return (ILocalSeedBatchRepository<ILocalSeedBatch>) _seedBatchRepository;
            }
        }

        public ILocalSeedTrayRepository<ILocalSeedTray> SeedTrayRepository
        {
            get
            {
                if (_seedTrayRepository == null)
                {
                    _seedTrayRepository = new EFSeedTrayRepository(this.Context);
                }

                return (ILocalSeedTrayRepository<ILocalSeedTray>) _seedTrayRepository;
            }
        }

        public ILocalSpeciesRepository<ILocalSpecies> SpeciesRepository
        {
            get
            {
                if (_speciesRepository == null)
                {
                    _speciesRepository = new EFSpeciesRepository(this.Context);
                }

                return (ILocalSpeciesRepository<ILocalSpecies>) _speciesRepository;
            }
        }

        public ILocalSiteRepository<ILocalSite> SiteRepository
        {
            get
            {
                if (_siteRepository == null)
                {
                    _siteRepository = new EFSiteRepository(this.Context);
                }

                return (ILocalSiteRepository<ILocalSite>)_siteRepository;
            }
        }

        #endregion Properties


        public void Commit()
        {
            this.Context.SaveChanges();
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
