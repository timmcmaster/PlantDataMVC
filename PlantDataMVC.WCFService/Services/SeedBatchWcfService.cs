﻿using Framework.WcfService;
using Interfaces.DAL.UnitOfWork;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.Services
{
    public class SeedBatchWcfService : WcfService<SeedBatch>,ISeedBatchWcfService
    {
        public SeedBatchWcfService(IUnitOfWorkAsync unitOfWork, ISeedBatchService service): base (unitOfWork,service)
        {
        }

        public ICreateResponse<SeedBatchDto> Create(SeedBatchDto item)
        {
            return base.Create<SeedBatchDto, SeedBatchDto>(item);
        }

        public IDeleteResponse<SeedBatchDto> Delete(int id)
        {
            return base.Delete<SeedBatchDto>(id);
        }

        public IListResponse<SeedBatchDto> List()
        {
            return base.List<SeedBatchDto>();
        }

        public IUpdateResponse<SeedBatchDto> Update(int id, SeedBatchDto item)
        {
            return base.Update<SeedBatchDto, SeedBatchDto>(id, item);
        }

        public IViewResponse<SeedBatchDto> View(int id)
        {
            return base.View<SeedBatchDto>(id);
        }
    }
}
