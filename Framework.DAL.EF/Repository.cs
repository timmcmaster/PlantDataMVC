using Framework.DAL.DataContext;
using Framework.DAL.Entity;
using Framework.DAL.Infrastructure;
using Framework.DAL.Repository;
//using Framework.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.DAL.EF
{
    /// <summary>
    /// The base class for a repository in the EF.Repositories space.
    /// All public methods are implemented in terms of Entity-derived classes (i.e. non-framework specific).
    /// This class uses the mapper to map the repository object from a Entity to an EntityObject. 
    /// It then calls the relevant datahandler CRUD operation which is implemented in terms of EntityObject-derived classes.
    /// </summary>
    /// <typeparam name="TEntity">The external Entity-derived type.</typeparam>
    /// <typeparam name="T">The internal EntityObject-derived type.</typeparam>
    public class Repository<TEntity> : IRepositoryAsync<TEntity>
        where TEntity : class, IEntity 
    {
        private IDataContextAsync _context;
        private IDbSet<TEntity> _dbSet;
        //private IUnitOfWorkAsync _unitOfWork;

        //public Repository(IDataContextAsync context, IUnitOfWorkAsync unitOfWork)
        public Repository(IDataContextAsync context)
            : base()
        {
            _context = context;
            //_unitOfWork = unitOfWork;

            // HACK: Feels dodgy to need to know which context type it is here
            // I suspect it is here because Set is an EF concept, not generic, hence not in interface 
            var dbContext = context as DbContext;

            if (dbContext != null)
            {
                _dbSet = dbContext.Set<TEntity>();
            }
            else
            {
                var fakeContext = context as FakeDbContext;

                if (fakeContext != null)
                {
                    _dbSet = fakeContext.Set<TEntity>();
                }
            }
        }

        #region IRepository implementation

        public IList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetItemById(int id)
        {
            return _dbSet.Find(id);
        }


        public TEntity GetItemById(int id, params Expression<System.Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _dbSet.Where(s => s.Id == id);

            // Do we want to throw an error if we find more than 1 object?

            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }

        public TEntity Add(TEntity item)
        {
            item.ObjectState = ObjectState.Added;
            _dbSet.Attach(item);
            _context.SyncObjectState(item);

            return item;
        }

        public TEntity Save(TEntity item)
        {
            // ObjectState is required here to ensure data actually gets saved
            // while also allowing non-EF implementations of generic pattern
            item.ObjectState = ObjectState.Modified;
            _dbSet.Attach(item);
            _context.SyncObjectState(item);

            return item;
        }

        public void Delete(TEntity item)
        {
            item.ObjectState = ObjectState.Deleted;
            _dbSet.Attach(item);
            _context.SyncObjectState(item);
        }

        public IQueryable<TEntity> Queryable()
        {
            return _dbSet;
        }

        //public IRepository<T> GetRepository<T>() where T : class, IEntity
        //{
        //    return _unitOfWork.Repository<T>();
        //}
        #endregion IRepository implementation


    }
}
