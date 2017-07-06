﻿using Framework.DAL.UnitOfWork;
using Framework.Domain;
using System.Collections.Generic;

namespace Framework.Service.ServiceLayer
{
    public abstract class BasicDataService<T> : IBasicDataService<T> where T : IDomainEntity
    {
        protected IUnitOfWorkAsync UnitOfWork { get; set; }

        public BasicDataService(IUnitOfWorkAsync unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public virtual CreateResponse<T> Create(CreateRequest<T> request)
        {
            using (var uow = this.UnitOfWork)
            {
                T createdItem = CreateItem(uow, request.Item);

                uow.SaveChanges();

                return new CreateResponse<T>(createdItem.Id, createdItem);
            }
        }

        public virtual ViewResponse<T> View(ViewRequest<T> request)
        {
            using (var uow = this.UnitOfWork)
            {
                T item = SelectItem(uow, request.Id);

                return new ViewResponse<T>(item);
            }
        }

        public virtual UpdateResponse<T> Update(UpdateRequest<T> request)
        {
            using (var uow = this.UnitOfWork)
            {
                T updatedItem = UpdateItem(uow, request.Item);

                uow.SaveChanges();

                return new UpdateResponse<T>(updatedItem);
            }
        }

        public virtual DeleteResponse<T> Delete(DeleteRequest<T> request)
        {
            using (var uow = this.UnitOfWork)
            {
                DeleteItem(uow, request.Id);

                uow.SaveChanges();

                return new DeleteResponse<T>();
            }
        }

        public virtual ListResponse<T> List(ListRequest<T> request)
        {
            using (var uow = this.UnitOfWork)
            {
                IList<T> itemList = ListItems(uow);

                return new ListResponse<T>(itemList);
            }
        }

        protected abstract T CreateItem(IUnitOfWorkAsync uow, T requestItem);
        protected abstract T SelectItem(IUnitOfWorkAsync uow, int id);
        protected abstract T UpdateItem(IUnitOfWorkAsync uow, T requestItem);
        protected abstract void DeleteItem(IUnitOfWorkAsync uow, int id);
        protected abstract IList<T> ListItems(IUnitOfWorkAsync uow);
    }
}