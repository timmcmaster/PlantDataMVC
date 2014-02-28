using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using PlantDataMvc3.DAL.LocalInterfaces;

namespace PlantDataMvc3.DAL.EF.Repositories
{
    /// <summary>
    /// The base class for a repository in the EF.Repositories space.
    /// All public methods are implemented in terms of Entity-derived classes (i.e. non-framework specific).
    /// This class uses the mapper to map the repository object from a Entity to an EntityObject. 
    /// It then calls the relevant datahandler CRUD operation which is implemented in terms of EntityObject-derived classes.
    /// </summary>
    /// <typeparam name="TDALEntity">The external Entity-derived type.</typeparam>
    /// <typeparam name="T">The internal EntityObject-derived type.</typeparam>
    public abstract class EFRepositoryBase<T> : ILocalRepository<T>
        where T : class, ILocalEntity 
    {
        private DbContext _context;
        private IDbSet<T> _dbSet;

        public DbContext Context
        {
            get
            {
                return _context;
            }
        }

        protected IDbSet<T> DbSet
        {
            get
            {
                return _dbSet;
            }
        }

        internal EFRepositoryBase(DbContext context)
            : base()
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        #region IRepository implementation

        public IList<T> GetAll()
        {
            return this.DbSet.ToList();
        }

        public T GetItemById(int id)
        {
            return this.DbSet.Find(id);
        }


        public T GetItemById(int id, params Expression<System.Func<T, object>>[] includes)
        {
            IQueryable<T> query = this.DbSet.Where(s => s.Id == id);

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

        public T Add(T item)
        {
            this.DbSet.Add(item);

            return item;
        }

        public T Save(T item)
        {
            this.Context.Entry<T>(item).State = System.Data.EntityState.Modified;

            return item;
        }

        public void Delete(T item)
        {
            this.DbSet.Remove(item);
        }
        #endregion IRepository implementation


    }
}
