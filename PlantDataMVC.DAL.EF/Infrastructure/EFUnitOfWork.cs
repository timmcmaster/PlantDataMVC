using PlantDataMVC.DAL.EF.Context;
using PlantDataMVC.DAL.EF.Entities;
using PlantDataMVC.DAL.EF.Repositories;
using PlantDataMVC.DAL.Interfaces;
using System;
using System.Data.Entity;

namespace PlantDataMVC.DAL.EF.Infrastructure
{
    /// <summary>
    /// Implements the UnitOfWork pattern 
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        #region Variables

        private bool _disposed = false;
        protected DbContext _context;

        protected IGenusRepository _genusRepository;
        protected IJournalEntryRepository _journalEntryRepository;
        protected IJournalEntryTypeRepository _journalEntryTypeRepository;
        protected IPlantStockRepository _plantStockRepository;
        protected IProductTypeRepository _productTypeRepository;
        protected ISeedBatchRepository _seedBatchRepository;
        protected ISeedTrayRepository _seedTrayRepository;
        protected ISpeciesRepository _speciesRepository;
        protected ISiteRepository _siteRepository;

        //protected IGenusRepository<Genus> _genusRepository;
        //protected IJournalEntryRepository<JournalEntry> _journalEntryRepository;
        //protected IJournalEntryTypeRepository<JournalEntryType> _journalEntryTypeRepository;
        //protected IPlantStockRepository<PlantStock> _plantStockRepository;
        //protected IProductTypeRepository<ProductType> _productTypeRepository;
        //protected ISeedBatchRepository<SeedBatch> _seedBatchRepository;
        //protected ISeedTrayRepository<SeedTray> _seedTrayRepository;
        //protected ISpeciesRepository<Species> _speciesRepository;
        //protected ISiteRepository<Site> _siteRepository;

        #endregion Variables

        public EFUnitOfWork()
            : this(new PlantDataDbContext())
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

        public IGenusRepository GenusRepository
        {
            get
            {
                if (_genusRepository == null)
                {
                    _genusRepository = (IGenusRepository) new EFGenusRepository(this.Context);
                }

                return (IGenusRepository<IGenus>) _genusRepository; 
            }
        }

        public IJournalEntryRepository<IJournalEntry> JournalEntryRepository
        {
            get
            {
                if (_journalEntryRepository == null)
                {
                    _journalEntryRepository = new EFJournalEntryRepository(this.Context);
                }

                return (IJournalEntryRepository<IJournalEntry>) _journalEntryRepository;
            }
        }

        public IJournalEntryTypeRepository<IJournalEntryType> JournalEntryTypeRepository
        {
            get
            {
                if (_journalEntryTypeRepository == null)
                {
                    _journalEntryTypeRepository = new EFJournalEntryTypeRepository(this.Context);
                }

                return (IJournalEntryTypeRepository<IJournalEntryType>) _journalEntryTypeRepository;
            }
        }

        public IPlantStockRepository<IPlantStock> PlantStockRepository
        {
            get
            {
                if (_plantStockRepository == null)
                {
                    _plantStockRepository = new EFPlantStockRepository(this.Context);
                }

                return (IPlantStockRepository<IPlantStock>) _plantStockRepository;
            }
        }

        public IProductTypeRepository<IProductType> ProductTypeRepository
        {
            get
            {
                if (_productTypeRepository == null)
                {
                    _productTypeRepository = new EFProductTypeRepository(this.Context);
                }

                return (IProductTypeRepository<IProductType>) _productTypeRepository;
            }
        }

        public ISeedBatchRepository<ISeedBatch> SeedBatchRepository
        {
            get
            {
                if (_seedBatchRepository == null)
                {
                    _seedBatchRepository = new EFSeedBatchRepository(this.Context);
                }

                return (ISeedBatchRepository<ISeedBatch>) _seedBatchRepository;
            }
        }

        public ISeedTrayRepository<ISeedTray> SeedTrayRepository
        {
            get
            {
                if (_seedTrayRepository == null)
                {
                    _seedTrayRepository = new EFSeedTrayRepository(this.Context);
                }

                return (ISeedTrayRepository<ISeedTray>) _seedTrayRepository;
            }
        }

        public ISpeciesRepository<ISpecies> SpeciesRepository
        {
            get
            {
                if (_speciesRepository == null)
                {
                    _speciesRepository = new EFSpeciesRepository(this.Context);
                }

                return (ISpeciesRepository<ISpecies>) _speciesRepository;
            }
        }

        public ISiteRepository<ISite> SiteRepository
        {
            get
            {
                if (_siteRepository == null)
                {
                    _siteRepository = new EFSiteRepository(this.Context);
                }

                return (ISiteRepository<ISite>)_siteRepository;
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
