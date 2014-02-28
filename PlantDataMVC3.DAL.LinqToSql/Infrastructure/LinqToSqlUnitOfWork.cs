using PlantDataMvc3.DAL.Interfaces;
using PlantDataMvc3.DAL.LinqToSql.Infrastructure;
using System;
using System.Data.Entity;
using PlantDataMvc3.DAL.LinqToSql.Entities;
using PlantDataMvc3.DAL.LinqToSql.Repositories;
using System.Data.Linq;

namespace PlantDataMvc3.DAL.LinqToSql.Infrastructure
{
    /// <summary>
    /// Implements the UnitOfWork pattern 
    /// </summary>
    public class LinqToSqlUnitOfWork: IUnitOfWork
    {
        #region Variables
        protected DataContext _context;

        protected LinqToSqlGenusRepository _genusRepository;
        protected LinqToSqlJournalEntryRepository _journalEntryRepository;
        protected LinqToSqlJournalEntryTypeRepository _journalEntryTypeRepository;
        protected LinqToSqlPlantStockRepository _plantStockRepository;
        protected LinqToSqlProductTypeRepository _productTypeRepository;
        protected LinqToSqlSeedBatchRepository _seedBatchRepository;
        protected LinqToSqlSeedTrayRepository _seedTrayRepository;
        protected LinqToSqlSpeciesRepository _speciesRepository;
        protected LinqToSqlSiteRepository _siteRepository;
        
        #endregion Variables

        public LinqToSqlUnitOfWork()
            : this(new PlantDataContext())
        {
        }

        public LinqToSqlUnitOfWork(DataContext context)
        {
            this.Context = context;
        }

        #region Properties

        protected DataContext Context { get; set; }

        public IGenusRepository GenusRepository
        {
            get 
            {
                if (_genusRepository == null)
                {
                    _genusRepository = new LinqToSqlGenusRepository(this.Context);
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
                    _journalEntryRepository = new LinqToSqlJournalEntryRepository(this.Context);
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
                    _journalEntryTypeRepository = new LinqToSqlJournalEntryTypeRepository(this.Context);
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
                    _plantStockRepository = new LinqToSqlPlantStockRepository(this.Context);
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
                    _productTypeRepository = new LinqToSqlProductTypeRepository(this.Context);
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
                    _seedBatchRepository = new LinqToSqlSeedBatchRepository(this.Context);
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
                    _seedTrayRepository = new LinqToSqlSeedTrayRepository(this.Context);
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
                    _speciesRepository = new LinqToSqlSpeciesRepository(this.Context);
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
                    _siteRepository = new LinqToSqlSiteRepository(this.Context);
                }

                return _siteRepository;
            }
        }

        #endregion Properties



        public void Commit()
        {
            this.Context.SubmitChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    //context.Dispose();
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
