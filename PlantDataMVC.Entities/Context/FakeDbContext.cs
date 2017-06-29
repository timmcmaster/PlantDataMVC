using Framework.DAL.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Framework.DAL.Entity;

namespace PlantDataMVC.Entities.Context
{
    /// <summary>
    /// This class contains the generic EF stuff for a fake context.
    /// It should be usable by any given database with its own entities.
    /// </summary>
    public abstract class FakeDbContext: IFakeDbContext
    {
        #region Private Fields  
        private readonly Dictionary<Type, object> _fakeDbSets;
        #endregion Private Fields

        protected FakeDbContext()
        {
            _fakeDbSets = new Dictionary<Type, object>();
        }

        public void Dispose()
        {
        }

        public int SaveChanges()
        {
            return default(int);
        }

        public DbSet<T> Set<T>() where T : class
        {
            return (DbSet<T>)_fakeDbSets[typeof(T)];
        }

        public void AddFakeDbSet<TEntity, TFakeDbSet>() 
            where TEntity : class, IEntity, new()
            where TFakeDbSet : MyFakeDbSet<TEntity>, IDbSet<TEntity>, new()
        {
            var fakeDbSet = Activator.CreateInstance<TFakeDbSet>();
            _fakeDbSets.Add(typeof(TEntity), fakeDbSet);
        }
    }
}
