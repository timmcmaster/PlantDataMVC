using Framework.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq.Expressions;

namespace Framework.DAL.EF
{
    public abstract class FakeDbSet<TEntity> : DbSet<TEntity>, IDbSet<TEntity> where TEntity : class, IEntity, new()
    {
        #region Private Fields
        private readonly ObservableCollection<TEntity> _items;
        private readonly IQueryable _query;
        #endregion Private Fields

        protected FakeDbSet()
        {
            _items = new ObservableCollection<TEntity>();
            _query = _items.AsQueryable();
        }

        // Note: Don't implement find generically - do that with specific derived sets
        IEnumerator IEnumerable.GetEnumerator() { return _items.GetEnumerator(); }
        public IEnumerator<TEntity> GetEnumerator() { return _items.GetEnumerator(); }

        public override ObservableCollection<TEntity> Local { get { return _items; } }

        public Expression Expression { get { return _query.Expression; } }

        public Type ElementType { get { return _query.ElementType; } }

        public IQueryProvider Provider { get { return _query.Provider; } }

        public override TEntity Add(TEntity entity)
        {
            if (entity == null) throw new System.ArgumentNullException("entity");
            _items.Add(entity);
            return entity;
        }

        public override TEntity Attach(TEntity entity)
        {
            // just doing add
            if (entity == null) throw new System.ArgumentNullException("entity");
            _items.Add(entity);
            return entity;
        }

        public override TEntity Create()
        {
            return new TEntity();
        }

        public override TEntity Remove(TEntity entity)
        {
            if (entity == null) throw new System.ArgumentNullException("entity");
            _items.Remove(entity);
            return entity;
        }

        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }
    }
}
