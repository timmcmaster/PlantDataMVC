using Framework.Service.Entities;
using Interfaces.DAL.Entity;
using Interfaces.DAL.UnitOfWork;
using Interfaces.Domain;
using Interfaces.DTO;
using Interfaces.Service;
using Interfaces.WCFService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Framework.Service
{
    public abstract class WcfService<TEntity> : IWcfService<TEntity> where TEntity : IDtoEntity
    {
        protected IUnitOfWorkAsync UnitOfWork { get; set; }

        public WcfService(IUnitOfWorkAsync unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        #region IDataServiceBase implementation
        public virtual ICreateResponse<TEntity> Create(TEntity item)
        {
            using (var uow = this.UnitOfWork)
            {
                TEntity createdItem = CreateItem(uow, item);

                uow.SaveChanges();

                return new CreateResponse<TEntity>(createdItem.Id, createdItem);
            }
        }

        public virtual IViewResponse<TEntity> View(int id)
        {
            using (var uow = this.UnitOfWork)
            {
                TEntity item = SelectItem(uow, id);

                return new ViewResponse<TEntity>(item);
            }
        }

        public virtual IUpdateResponse<TEntity> Update(int id, TEntity item)
        {
            using (var uow = this.UnitOfWork)
            {
                // TODO: Add check for id matches Item.Id
                
                TEntity updatedItem = UpdateItem(uow, item);

                //uow.SaveChanges();

                return new UpdateResponse<TEntity>(updatedItem);
            }
        }

        public virtual IDeleteResponse<TEntity> Delete(int id)
        {
            using (var uow = this.UnitOfWork)
            {
                var response = new DeleteResponse<TEntity>();

                try
                {
                    DeleteItem(uow, id);

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

        public virtual IListResponse<TEntity> List()
        {
            using (var uow = this.UnitOfWork)
            {
                IList<TEntity> itemList = ListItems(uow);

                return new ListResponse<TEntity>(itemList);
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
        protected abstract TEntity CreateItem(IUnitOfWorkAsync uow, TEntity requestItem);

        /// <summary>
        /// Selects the item.
        /// </summary>
        /// <param name="uow">The unit of work.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        protected abstract TEntity SelectItem(IUnitOfWorkAsync uow, int id);

        /// <summary>
        /// Updates the item passed in against the unit of work.
        /// Implementations need to handle saving changes against the unit of work.
        /// </summary>
        /// <param name="uow">The unit of work.</param>
        /// <param name="requestItem">The request item.</param>
        /// <returns></returns>
        protected abstract TEntity UpdateItem(IUnitOfWorkAsync uow, TEntity requestItem);

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
        /// <returns>A list of type <typeparamref name="TEntity"/></returns>
        protected abstract IList<TEntity> ListItems(IUnitOfWorkAsync uow);
    }
}