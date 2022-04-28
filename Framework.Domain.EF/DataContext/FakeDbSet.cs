using Interfaces.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Domain.EF
{
    public abstract class FakeDbSet<TEntity> : DbSet<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly ObservableCollection<TEntity> _items;
        private readonly IQueryable _query;

        protected FakeDbSet()
        {
            _items = new ObservableCollection<TEntity>();
            _query = _items.AsQueryable();
        }

        #region DbSet<TEntity> Members
        // Note: Don't implement find generically - do that with specific derived sets
        public IEnumerator<TEntity> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        //public override ObservableCollection<TEntity> Local
        //{
        //    get => _items;
        //}

        public Expression Expression
        {
            get => _query.Expression;
        }

        public Type ElementType
        {
            get => _query.ElementType;
        }

        public IQueryProvider Provider
        {
            get => _query.Provider;
        }

        public override EntityEntry<TEntity> Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _items.Add(entity);
            return null;
        }

        public override EntityEntry<TEntity> Attach(TEntity entity)
        {
            // just doing add
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _items.Add(entity);
            return null;
        }

        public override EntityEntry<TEntity> Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _items.Remove(entity);
            return null;
        }
        #endregion
    }
}