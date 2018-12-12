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
        public virtual ICreateResponse<T> Create(ICreateRequest<T> request)
        {
            using (var uow = this.UnitOfWork)
            {
                T createdItem = CreateItem(uow, request.Item);

                uow.SaveChanges();

                return new CreateResponse<T>(createdItem.Id, createdItem);
            }
        }

        public virtual IViewResponse<T> View(IViewRequest<T> request)
        {
            using (var uow = this.UnitOfWork)
            {
                T item = SelectItem(uow, request.Id);

                return new ViewResponse<T>(item);
            }
        }

        public virtual IUpdateResponse<T> Update(IUpdateRequest<T> request)
        {
            using (var uow = this.UnitOfWork)
            {
                T updatedItem = UpdateItem(uow, request.Item);

                //uow.SaveChanges();

                return new UpdateResponse<T>(updatedItem);
            }
        }

        public virtual IDeleteResponse<T> Delete(IDeleteRequest<T> request)
        {
            using (var uow = this.UnitOfWork)
            {
                var response = new DeleteResponse<T>();

                try
                {
                    DeleteItem(uow, request.Id);

                    uow.SaveChanges();
                }
                catch (SqlException ex)
                {
                    response.ErrorCode = ex.Number;
                    throw; // to ensure error is seen for now
                }
                finally
                {
                }

                return response;
            }
        }

        public virtual IListResponse<T> List(IListRequest<T> request)
        {
            using (var uow = this.UnitOfWork)
            {
                IList<T> itemList = ListItems(uow);

                return new ListResponse<T>(itemList);
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