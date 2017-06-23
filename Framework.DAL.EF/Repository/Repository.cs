using Framework.DAL.Entity;
using Framework.DAL.Repository;
//using Framework.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System;
using Framework.DAL.DataContext;

namespace Framework.DAL.EF.Repository
{
    /// <summary>
    /// The base class for a repository in the EF.Repositories space.
    /// All public methods are implemented in terms of Entity-derived classes (i.e. non-framework specific).
    /// This class uses the mapper to map the repository object from a Entity to an EntityObject. 
    /// It then calls the relevant datahandler CRUD operation which is implemented in terms of EntityObject-derived classes.
    /// </summary>
    /// <typeparam name="TEntity">The external Entity-derived type.</typeparam>
    /// <typeparam name="T">The internal EntityObject-derived type.</typeparam>
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity 
    {
        private IDataContext _context;
        private IDbSet<TEntity> _dbSet;
        //private IUnitOfWork _unitOfWork;

        //public Repository(DbContext context, IUnitOfWork unitOfWork)
        public Repository(IDataContext context)
            : base()
        {
            _context = context;
            //_unitOfWork = unitOfWork;

            var dbContext = context as DbContext;

            if (dbContext != null)
            {
                _dbSet = dbContext.Set<TEntity>();
            }
            else
            { }

            _dbSet = context.Set<TEntity>();
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
            _dbSet.Add(item);

            return item;
        }

        public TEntity Save(TEntity item)
        {
            this.Context.Entry<TEntity>(item).State = System.Data.Entity.EntityState.Modified;

            return item;
        }

        public void Delete(TEntity item)
        {
            _dbSet.Remove(item);
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
