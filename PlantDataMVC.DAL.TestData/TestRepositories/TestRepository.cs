using Framework.DAL.Entity;
using Framework.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDataMVC.DAL.TestData
{
    public abstract class TestRepository<T> : IRepository<T>
        where T : class, IEntity
    {
        protected static Random _randomGen = new Random();

        public TestRepository()
        {
        }

        #region IRepository implementation

        public virtual IList<T> GetAll()
        {
            return ListItems();
        }

        public virtual T GetItemById(int id)
        {
            return SelectItem(id);
        }

        public virtual T GetItemById(int id, params System.Linq.Expressions.Expression<Func<T, object>>[] includes)
        {
            // TODO: Implement property filling
            return SelectItem(id);
        }

        public virtual T Add(T item)
        {
            T createdItem = CreateItem(item);

            return createdItem;
        }

        public virtual T Save(T item)
        {
            T updatedItem = UpdateItem(item);

            return updatedItem;
        }

        public virtual void Delete(T item)
        {
            DeleteItem(item.Id);
        }

        #endregion

        #region Basic Operations on Local entities

        public abstract T CreateItem(T requestItem);
        public abstract T SelectItem(int id);
        public abstract T UpdateItem(T requestItem);
        public abstract void DeleteItem(int id);
        public abstract IList<T> ListItems();

        public IQueryable<T> Queryable()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
