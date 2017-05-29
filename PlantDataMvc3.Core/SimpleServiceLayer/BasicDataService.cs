using System;
using System.Collections.Generic;
using PlantDataMvc3.Core.Domain.BusinessObjects;
using PlantDataMvc3.Core.ServiceLayer;
using PlantDataMVC.DAL.Interfaces;
using PlantDataMvc3.Core.DataAccess;

namespace PlantDataMvc3.Core.SimpleServiceLayer
{
    public abstract class BasicDataService<T> : IBasicDataService<T> where T : DomainEntity
    {
        protected IUnitOfWorkManager UnitOfWorkManager { get; set; }
        //protected IUnitOfWork UnitOfWork { get; set; }
        
        public BasicDataService(IUnitOfWorkManager uowManager)
        {
            this.UnitOfWorkManager = uowManager;
        }

        //public BasicDataService(IUnitOfWork unitOfWork)
        //{
        //    this.UnitOfWork = unitOfWork;
        //}

        public virtual CreateResponse<T> Create(CreateRequest<T> request)
        {
            using (var uow = this.UnitOfWorkManager.GetUnitOfWork())
            {
                T createdItem = CreateItem(uow, request.Item);

                uow.Commit();

                return new CreateResponse<T>(createdItem.Id, createdItem);
            }
        }

        public virtual ViewResponse<T> View(ViewRequest<T> request)
        {
            using (var uow = this.UnitOfWorkManager.GetUnitOfWork())
            {
                T item = SelectItem(uow, request.Id);

                return new ViewResponse<T>(item);
            }
        }

        public virtual UpdateResponse<T> Update(UpdateRequest<T> request)
        {
            using (var uow = this.UnitOfWorkManager.GetUnitOfWork())
            {
                T updatedItem = UpdateItem(uow, request.Item);

                uow.Commit();

                return new UpdateResponse<T>(updatedItem);
            }
        }

        public virtual DeleteResponse<T> Delete(DeleteRequest<T> request)
        {
            using (var uow = this.UnitOfWorkManager.GetUnitOfWork())
            {
                DeleteItem(uow, request.Id);

                uow.Commit();

                return new DeleteResponse<T>();
            }
        }

        public virtual ListResponse<T> List(ListRequest<T> request)
        {
            using (var uow = this.UnitOfWorkManager.GetUnitOfWork())
            {
                IList<T> itemList = ListItems(uow);

                return new ListResponse<T>(itemList);
            }
        }

        protected abstract T CreateItem(IUnitOfWork uow, T requestItem);
        protected abstract T SelectItem(IUnitOfWork uow, int id);
        protected abstract T UpdateItem(IUnitOfWork uow, T requestItem);
        protected abstract void DeleteItem(IUnitOfWork uow, int id);
        protected abstract IList<T> ListItems(IUnitOfWork uow);
    }
}