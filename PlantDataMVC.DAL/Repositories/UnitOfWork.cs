using System;
using System.Data.Entity;
using PlantDataMvc3.DAL.Interfaces;

namespace PlantDataMvc3.DAL.Repositories
{
    /// <summary>
    /// Implements the UnitOfWork pattern 
    /// Maps from the local entities to the entities exposed by the DAL.
    /// Wraps a local unit of work to commit at the base level.
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Variables

        private bool _disposed = false;

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
        public UnitOfWork()
        {
        }

        #region Properties

        /// <summary>
        /// Implement lazy initialisation of genus repository object using  repos.
        /// </summary>
        public IGenusRepository GenusRepository
        {
            get
            {
                if (_genusRepository == null)
                {
                    _genusRepository = (IGenusRepository) new GenusRepository();
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
                    _journalEntryRepository = (IJournalEntryRepository) new JournalEntryRepository();
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
                    _journalEntryTypeRepository = (IJournalEntryTypeRepository) new JournalEntryTypeRepository();
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
                    _plantStockRepository = (IPlantStockRepository) new PlantStockRepository();
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
                    _productTypeRepository = (IProductTypeRepository) new ProductTypeRepository();
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
                    _seedBatchRepository = (ISeedBatchRepository) new SeedBatchRepository();
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
                    _seedTrayRepository = (ISeedTrayRepository) new SeedTrayRepository();
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
                    _speciesRepository = (ISpeciesRepository) new SpeciesRepository();
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
                    _siteRepository = (ISiteRepository) new SiteRepository();
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
 