using Interfaces.Domain.Entity;
using Interfaces.Domain.Repository;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Framework.Domain.EF
{
    /// <summary>
    ///     The base class for a repository.
    ///     All public methods are implemented in terms of Entity-derived classes (i.e. non-framework specific).
    /// </summary>
    /// <typeparam name="TEntity">The external Entity-derived type.</typeparam>
    public class EFRepository<TEntity> : IRepositoryAsync<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        //private readonly IUnitOfWorkAsync _unitOfWork;

        //public EFRepository(IDbContext context, IUnitOfWorkAsync unitOfWork)
        public EFRepository(IDbContext context)
        {
            _context = context;
            //_unitOfWork = unitOfWork;

            // HACK: Feels dodgy to need to know which context type it is here
            // I suspect it is here because Set is an EF concept, not generic, hence not in interface 

            //switch (context)
            //{
            //    case DbContext dbContext:
            //        _dbSet = dbContext.Set<TEntity>();
            //        break;
            //    case FakeDbContext fakeContext:
            //        _dbSet = fakeContext.Set<TEntity>();
            //        break;
            //}
            _dbSet = _context.Set<TEntity>();
        }

        #region IRepositoryAsync<TEntity> Members
        public IQueryable<TEntity> GetAllItems()
        {
            return _dbSet.AsQueryable<TEntity>();
        }

        public IQueryable<TEntity> GetAllItemsAsNoTracking()
        {
            return _dbSet.AsNoTracking<TEntity>();
        }

        public virtual TEntity GetItemById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual TEntity GetItemById(string id)
        {
            return _dbSet.Find(id);
        }

        public virtual TEntity GetItemById<U>(U id)
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

        public virtual void Add(TEntity item)
        {
            var entityState = _context.GetState(item);
            if (entityState != EntityState.Detached)
            {
                _context.SetState(item, EntityState.Added);
            }
            else
            {
                _dbSet.Add(item);
            }
        }

        //public virtual void AddRange(List<TEntity> itemList)
        //{
        //    _dbSet.AddRange(itemList);
        //}

        public virtual void Update(TEntity item)
        {
            var entityState = _context.GetState<TEntity>(item);
            if (entityState == EntityState.Detached)
                _dbSet.Attach(item);

            if (entityState != EntityState.Added)
                _context.SetState(item, EntityState.Modified);
        }

        public void Delete(TEntity item)
        {
            var entityState = _context.GetState<TEntity>(item);
            if (entityState != EntityState.Deleted)
            {
                _context.SetState(item, EntityState.Deleted);
            }
            else
            {
                _dbSet.Attach(item);
                _dbSet.Remove(item);
            }
        }

        public void Delete(int id)
        {
            var entity = GetItemById(id);
            if (entity == null)
                return;
            Delete(entity);
        }

        public void Delete(string id)
        {
            var entity = GetItemById(id);
            if (entity == null)
                return;
            Delete(entity);
        }

        public void Delete<U>(U id)
        {
            var entity = GetItemById(id);
            if (entity == null)
                return;
            Delete(entity);
        }

        public virtual void Remove(TEntity item)
        {
            //var entry = _context.Entry(item);
            //if (entry != null)
            //{
            var entityState = _context.GetState(item);
            if (entityState == EntityState.Added)
                _context.SetState(item, EntityState.Detached);
            else
                Delete(item);
            //}
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

        public IQueryable<TEntity> Queryable()
        {
            return _dbSet;
        }

        public IQueryable<TEntity> QueryableAsNoTracking()
        {
            return _dbSet.AsNoTracking<TEntity>();
        }

        //public IRepository<TOtherEntity> GetRepository<TOtherEntity>() where TOtherEntity : class, IEntity
        //{
        //    return _unitOfWork.Repository<TOtherEntity>();
        //}
        #endregion


        public virtual void Detach(TEntity item)
        {
            var entityState = _context.GetState(item);
            if (entityState != EntityState.Detached)
            {
                _context.SetState(item,EntityState.Detached);
            }
        }

        /// <summary>
        /// Detach an object from the context, can be used to force future refreshes of the object from the db
        /// </summary>
        /// <param name="id"></param>
        public virtual void Detach(String id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
                return;
            Detach(entity);
        }

        public virtual void Detach<U>(U id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
                return;
            Detach(entity);
        }

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

        /// <summary>
        /// Note, do not use this method if you want to query for a list and then track changes,
        /// use GetAllItems below
        /// </summary>
        /// <returns></returns>
        // Note: This is same as Queryable() method
        protected virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

    }
}