using System.Collections.Generic;
using AutoMapper;
using PlantDataMVC.DAL.Interfaces;
using PlantDataMVC.DAL.Repositories;
using PlantDataMVC.DAL.LinqToSql.Infrastructure;
using System.Data.Linq;
using System.Linq;
using System;
using System.Linq.Expressions;

namespace PlantDataMVC.DAL.LinqToSql.Repositories
{
    /// <summary>
    /// The base class for a repository in the LinqToSql.Repositories space.
    /// All public methods are implemented in terms of Entity-derived classes (i.e. non-framework specific).
    /// This class uses the mapper to map the repository object from an Entity to a LinqToSql.Entities type 
    /// It then calls the relevant datahandler CRUD operation which is implemented in terms of LinqToSql.Entities classes.
    /// </summary>
    /// <typeparam name="TDALEntity">The external Entity-derived type.</typeparam>
    /// <typeparam name="TLocalEntity">The internal LinqToSql.Entities type.</typeparam>
    public abstract class LinqToSqlRepositoryBase<TDALEntity, TLocalEntity> : MappingRepository<TDALEntity,TLocalEntity>
        where TDALEntity : DAL.Entities.Entity
        where TLocalEntity : class, LinqToSql.Entities.Entity

    {
        //private LinqToSqlRepositoryContext _repositoryContext;
        private DataContext _context;
        private ITable<TLocalEntity> _table;

        //public LinqToSqlRepositoryContext RepositoryContext
        //{
        //    get
        //    {
        //        return _repositoryContext;
        //    }
        //}

        public DataContext Context
        {
            get
            {
                return _context;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected ITable<TLocalEntity> Table
        {
            get
            {
                return _table;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dataHandler">The DataHandler to use</param>
        internal LinqToSqlRepositoryBase(DataContext context): base()
        {
            _context = context;
            _table = context.GetTable<TLocalEntity>();
        }

        #region IRepository implementation


        #endregion IRepository implementation

        #region Basic Operations on Local entities

        protected override TLocalEntity CreateItem(TLocalEntity requestItem)
        {
            this.Table.InsertOnSubmit(requestItem);
            //this.RepositoryContext.SaveChanges();

            return requestItem;
        }

        protected override TLocalEntity SelectItem(int id)
        {
            //return this.Table.Single(p => p.Id == id);
            return this.Table.FirstOrDefault(p => p.Id == id);
        }

        protected override TLocalEntity SelectItem(int id, IList<string> includeProperties)
        {
            IQueryable<TLocalEntity> query = this.Table.Where(p => p.Id == id);

            // Do we want to throw an error if we find more than 1 object?

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    // include this property
                }
            }

            return query.FirstOrDefault();
        }

        protected override TLocalEntity UpdateItem(TLocalEntity requestItem)
        {
            // TODO: Not yet sure how linq to sql tables are best updated
            this.Table.Attach(requestItem);

            return requestItem;
        }

        protected override void DeleteItem(int id)
        {
            TLocalEntity item = SelectItem(id);

            this.Table.DeleteOnSubmit(item);
            //this.RepositoryContext.SaveChanges();
        }

        protected override IList<TLocalEntity> ListItems(Expression<Func<IQueryable<TLocalEntity>, IOrderedQueryable<TLocalEntity>>> orderBy = null, List<string> includeProperties = null)
        {
            // TODO: Implement orderBy and Include properties
            IQueryable<TLocalEntity> query = this.Table;

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    //query = query.Include(includeProperty);
                }
            }


            // If order is specified, return specified order, 
            // else repository default order, 
            // else DB default order
            if (orderBy != null)
            {
                Func<IQueryable<TLocalEntity>, IOrderedQueryable<TLocalEntity>> funcOrderBy = orderBy.Compile();
                return query.OrderBy(funcOrderBy);
                //return orderBy(query).ToList();
            }
            else if (this.DefaultOrderBy != null)
            {
                return this.DefaultOrderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        #endregion Basic Operations on Local entities

    }
}
