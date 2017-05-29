using System;
using System.Data.Entity;
using PlantDataMVC.DAL.Interfaces;
using PlantDataMVC.DAL.LocalInterfaces;

namespace PlantDataMVC.DAL.MappingRepositories
{
    /// <summary>
    /// Implements the UnitOfWork pattern 
    /// Maps from the local entities to the entities exposed by the DAL.
    /// Wraps a local unit of work to commit at the base level.
    /// </summary>
    public class MappingUnitOfWork : IUnitOfWork, IDisposable
    {
        #region Variables

        private bool _disposed = false;

        protected ILocalUnitOfWork _uow;

        protected IGenusRepository _genusRepository;
        protected IJournalEntryRepository _journalEntryRepository;
        protected IJournalEntryTypeRepository _journalEntryTypeRepository;
        protected IPlantStockRepository _plantStockRepository;
        protected IProductTypeRepository _productTypeRepository;
        protected ISeedBatchRepository _seedBatchRepository;
        protected ISeedTrayRepository _seedTrayRepository;
        protected ISpeciesRepository _speciesRepository;
        protected ISiteRepository _siteRepository;

        #endregion Variables

        /// <summary>
        /// Constructor.
        /// Takes a local uow object
        /// </summary>
        /// <param name="localUow"></param>
        public MappingUnitOfWork(ILocalUnitOfWork localUow)
        {
            this.Uow = localUow;
        }

        #region Properties

        protected ILocalUnitOfWork Uow
        {
            get { return _uow; }
            set { _uow = value; }
        }

        /// <summary>
        /// Implement lazy initialisation of genus repository object using mapping repos.
        /// </summary>
        public IGenusRepository GenusRepository
        {
            get
            {
                if (_genusRepository == null)
                {
                    _genusRepository = (IGenusRepository) new GenusMappingRepository<ILocalGenus>(_uow.GenusRepository);
                }

                return _genusRepository;
            }
        }

        public IJournalEntryRepository JournalEntryRepository
        {
            get
            {
                if (_journalEntryRepository == null)
                {
                    _journalEntryRepository = (IJournalEntryRepository) new JournalEntryMappingRepository<ILocalJournalEntry>(_uow.JournalEntryRepository);
                }

                return _journalEntryRepository;
            }
        }

        public IJournalEntryTypeRepository JournalEntryTypeRepository
        {
            get
            {
                if (_journalEntryTypeRepository == null)
                {
                    _journalEntryTypeRepository = (IJournalEntryTypeRepository) new JournalEntryTypeMappingRepository<ILocalJournalEntryType>(_uow.JournalEntryTypeRepository);
                }

                return _journalEntryTypeRepository;
            }
        }

        public IPlantStockRepository PlantStockRepository
        {
            get
            {
                if (_plantStockRepository == null)
                {
                    _plantStockRepository = (IPlantStockRepository) new PlantStockMappingRepository<ILocalPlantStock>(_uow.PlantStockRepository);
                }

                return _plantStockRepository;
            }
        }

        public IProductTypeRepository ProductTypeRepository
        {
            get
            {
                if (_productTypeRepository == null)
                {
                    _productTypeRepository = (IProductTypeRepository) new ProductTypeMappingRepository<ILocalProductType>(_uow.ProductTypeRepository);
                }

                return _productTypeRepository;
            }
        }

        public ISeedBatchRepository SeedBatchRepository
        {
            get
            {
                if (_seedBatchRepository == null)
                {
                    _seedBatchRepository = (ISeedBatchRepository)new SeedBatchMappingRepository<ILocalSeedBatch>(_uow.SeedBatchRepository);
                }

                return _seedBatchRepository;
            }
        }

        public ISeedTrayRepository SeedTrayRepository
        {
            get
            {
                if (_seedTrayRepository == null)
                {
                    _seedTrayRepository = (ISeedTrayRepository)new SeedTrayMappingRepository<ILocalSeedTray>(_uow.SeedTrayRepository);
                }

                return _seedTrayRepository;
            }
        }

        public ISpeciesRepository SpeciesRepository
        {
            get
            {
                if (_speciesRepository == null)
                {
                    _speciesRepository = (ISpeciesRepository)new SpeciesMappingRepository<ILocalSpecies>(_uow.SpeciesRepository);
                }

                return _speciesRepository;
            }
        }

        public ISiteRepository SiteRepository
        {
            get
            {
                if (_siteRepository == null)
                {
                    _siteRepository = (ISiteRepository)new SiteMappingRepository<ILocalSite>(_uow.SiteRepository);
                }

                return _siteRepository;
            }
        }

        #endregion Properties


        public void Commit()
        {
            _uow.Commit();
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _uow.Dispose();
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
 