using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Interfaces.Domain.DataContext;
using Interfaces.Domain.Entity;
using Interfaces.Domain.Infrastructure;
using Interfaces.Domain.Repository;
using Interfaces.Domain.UnitOfWork;
using LinqKit;

namespace Framework.Domain.EF
{
    /// <summary>
    ///     The base class for a repository.
    ///     All public methods are implemented in terms of Entity-derived classes (i.e. non-framework specific).
    /// </summary>
    /// <typeparam name="TEntity">The external Entity-derived type.</typeparam>
    public class Repository<TEntity> : IRepositoryAsync<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IDataContextAsync _context;
        private readonly IDbSet<TEntity> _dbSet;
        private readonly IUnitOfWorkAsync _unitOfWork;

        public Repository(IDataContextAsync context, IUnitOfWorkAsync unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;

            // HACK: Feels dodgy to need to know which context type it is here
            // I suspect it is here because Set is an EF concept, not generic, hence not in interface 

            switch (context)
            {
                case DbContext dbContext:
                    _dbSet = dbContext.Set<TEntity>();
                    break;
                case FakeDbContext fakeContext:
                    _dbSet = fakeContext.Set<TEntity>();
                    break;
            }
        }

        #region IRepositoryAsync<TEntity> Members
        // Note: This is same as Queryable() method
        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public TEntity GetItemById(int id)
        {
            return _dbSet.Find(id);
        }


        //public TEntity GetItemById(int id, params Expression<System.Func<TEntity, object>>[] includes)
        //{
        //    IQueryable<TEntity> query = _dbSet.Where(s => s.Id == id);

        //    // Do we want to throw an error if we find more than 1 object?

        //    if (includes != null)
        //    {
        //        foreach (var includeProperty in includes)
        //        {
        //            query = query.Include(includeProperty);
        //        }
        //    }

        //    return query.FirstOrDefault();
        //}

        public TEntity Add(TEntity item)
        {
            item.ObjectState = ObjectState.Added;
            _dbSet.Attach(item);
            _context.SyncObjectState(item);

            return item;
        }

        public TEntity Save(TEntity item)
        {
            // TODO: Does save need to be a detach of existing and attach of new item
            //       in order to implement PUT method properly?

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

        public IRepository<TOtherEntity> GetRepository<TOtherEntity>() where TOtherEntity : class, IEntity
        {
            return _unitOfWork.Repository<TOtherEntity>();
        }

        public IQueryFluent<TEntity> Query()
        {
            return new QueryFluent<TEntity>(this);
        }

        public IQueryFluent<TEntity> Query(IQueryObject<TEntity> queryObject)
        {
            return new QueryFluent<TEntity>(this, queryObject);
        }

        public IQueryFluent<TEntity> Query(Expression<Func<TEntity, bool>> query)
        {
            return new QueryFluent<TEntity>(this, query);
        }
        #endregion


        internal IQueryable<TEntity> Select(Expression<Func<TEntity, bool>> filter = null,
                                            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                            List<Expression<Func<TEntity, object>>> includes = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (filter != null)
            {
                query = query.AsExpandable().Where(filter);
            }

            return query;
        }

        internal async Task<IEnumerable<TEntity>> SelectAsync(Expression<Func<TEntity, bool>> filter = null,
                                                              Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>
                                                                  orderBy = null,
                                                              List<Expression<Func<TEntity, object>>> includes = null)
        {
            return await Select(filter, orderBy, includes).ToListAsync();
        }
    }
}