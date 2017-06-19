﻿using System;
using System.Collections.Generic;
using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMVC.Core.ServiceLayer;
using Framework.DAL.UnitOfWork;

namespace PlantDataMVC.Core.SimpleServiceLayer
{
    public abstract class BasicDataService<T> : IBasicDataService<T> where T : DomainEntity
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        public BasicDataService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public virtual CreateResponse<T> Create(CreateRequest<T> request)
        {
            using (var uow = this.UnitOfWork)
            {
                T createdItem = CreateItem(uow, request.Item);

                uow.Commit();

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

                uow.Commit();

                return new UpdateResponse<T>(updatedItem);
            }
        }

        public virtual DeleteResponse<T> Delete(DeleteRequest<T> request)
        {
            using (var uow = this.UnitOfWork)
            {
                DeleteItem(uow, request.Id);

                uow.Commit();

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

        protected abstract T CreateItem(IUnitOfWork uow, T requestItem);
        protected abstract T SelectItem(IUnitOfWork uow, int id);
        protected abstract T UpdateItem(IUnitOfWork uow, T requestItem);
        protected abstract void DeleteItem(IUnitOfWork uow, int id);
        protected abstract IList<T> ListItems(IUnitOfWork uow);
    }
}