using Framework.Service.Entities;
using Interfaces.DAL.UnitOfWork;
using Interfaces.Domain;
using Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Framework.Service
{
    public abstract class DataServiceBase<T> : IDataServiceBase<T> where T : IDomainEntity
    {
        protected IUnitOfWorkAsync UnitOfWork { get; set; }

        public DataServiceBase(IUnitOfWorkAsync unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        #region IDataServiceBase implementation
        public virtual ICreateResponse<T> Create(T item)
        {
            using (var uow = this.UnitOfWork)
            {
                try
                {
                    T createdItem = CreateItem(uow, item);

                    var changes = uow.SaveChanges();
                    if (changes > 0)
                    {
                        return new CreateResponse<T>(createdItem.Id, createdItem, ServiceActionStatus.Created);
                    }
                    else
                    {
                        return new CreateResponse<T>(createdItem.Id, createdItem, ServiceActionStatus.NothingModified);
                    }
                }
                catch (Exception ex)
                {
                    // Use default(T) instead of null
                    // TODO: error code is erroneous
                    return new CreateResponse<T>(0, default(T), ServiceActionStatus.Error, 1);
                }
            }
        }

        public virtual IViewResponse<T> View(int id)
        {
            using (var uow = this.UnitOfWork)
            {
                T item = SelectItem(uow, id);

                if (item == null)
                {
                    return new ViewResponse<T>(item, ServiceActionStatus.NotFound);
                }
                else
                {
                    return new ViewResponse<T>(item, ServiceActionStatus.Ok);
                }
            }
        }

        public virtual IUpdateResponse<T> Update(int id, T item)
        {
            using (var uow = this.UnitOfWork)
            {
                try
                {
                    // Check item exists before updating
                    var selectedItem = SelectItem(uow, id);

                    if (selectedItem == null)
                    {
                        return new UpdateResponse<T>(item, ServiceActionStatus.NotFound);
                    }

                    // TODO: Add check for id matches Item.Id?

                    T updatedItem = UpdateItem(uow, item);

                    var changes = uow.SaveChanges();
                    if (changes > 0)
                    {
                        return new UpdateResponse<T>(updatedItem, ServiceActionStatus.Updated);
                    }
                    else
                    {
                        return new UpdateResponse<T>(updatedItem, ServiceActionStatus.NothingModified);
                    }
                }
                catch(Exception ex)
                {
                    // Use default(T) instead of null
                    // TODO: error code is erroneous
                    return new UpdateResponse<T>(default(T), ServiceActionStatus.Error, 1);
                }
            }
        }

        public virtual IDeleteResponse<T> Delete(int id)
        {
            using (var uow = this.UnitOfWork)
            {
                try
                {
                    // Check item exists before updating
                    var selectedItem = SelectItem(uow, id);

                    if (selectedItem == null)
                    {
                        return new DeleteResponse<T>(ServiceActionStatus.NotFound);
                    }
                    else
                    {
                        DeleteItem(uow, id);

                        //uow.SaveChanges();
                        return new DeleteResponse<T>(ServiceActionStatus.Deleted);
                    }
                }
                catch (Exception ex)
                {
                    // TODO: error code is erroneous
                    return new DeleteResponse<T>(ServiceActionStatus.Error, 1);
                }
            }
        }

        public virtual IListResponse<T> List()
        {
            using (var uow = this.UnitOfWork)
            {
                try
                {
                    IList<T> itemList = ListItems(uow);

                    return new ListResponse<T>(itemList, ServiceActionStatus.Ok);
                }
                catch (Exception ex)
                {
                    // TODO: fix setting bound type to null and error code
                    return new ListResponse<T>(null, ServiceActionStatus.Error, 1);
                }
            }
        }
        #endregion

        /// <summary>
        /// Creates the item against the unit of work.
        /// Implementations need to handle saving changes against the unit of work.
        /// </summary>
        /// <param name="uow">The unit of work.</param>
        /// <param name="requestItem">The request item.</param>
        /// <returns></returns>
        protected abstract T CreateItem(IUnitOfWorkAsync uow, T requestItem);

        /// <summary>
        /// Selects the item.
        /// </summary>
        /// <param name="uow">The unit of work.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        protected abstract T SelectItem(IUnitOfWorkAsync uow, int id);

        /// <summary>
        /// Updates the item passed in against the unit of work.
        /// Implementations need to handle saving changes against the unit of work.
        /// </summary>
        /// <param name="uow">The unit of work.</param>
        /// <param name="requestItem">The request item.</param>
        /// <returns></returns>
        protected abstract T UpdateItem(IUnitOfWorkAsync uow, T requestItem);

        /// <summary>
        /// Deletes the item with given id against the unit of work.
        /// Implementations need to handle saving changes against the unit of work.
        /// </summary>
        /// <param name="uow">The unit of work.</param>
        /// <param name="id">The identifier.</param>
        protected abstract void DeleteItem(IUnitOfWorkAsync uow, int id);

        /// <summary>
        /// Lists the items.
        /// </summary>
        /// <param name="uow">The unit of work.</param>
        /// <returns>A list of type <typeparamref name="T"/></returns>
        protected abstract IList<T> ListItems(IUnitOfWorkAsync uow);
    }
}