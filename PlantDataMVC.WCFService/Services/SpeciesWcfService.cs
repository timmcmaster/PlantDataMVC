﻿using Interfaces.DAL.UnitOfWork;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.Services
{
    public class SpeciesWcfService : WcfService<Species>, ISpeciesWcfService
    {
        public SpeciesWcfService(IUnitOfWorkAsync uow, ISpeciesService service): base (uow,service)
        {
        }

        public ICreateResponse<SpeciesDto> Create(SpeciesDto item)
        {
            return base.Create<SpeciesDto, SpeciesDto>(item);
        }

        public IDeleteResponse<SpeciesDto> Delete(int id)
        {
            return base.Delete<SpeciesDto>(id);
        }

        public IListResponse<SpeciesDto> List()
        {
            return base.List<SpeciesDto>();
        }

        public IUpdateResponse<SpeciesDto> Update(int id, SpeciesDto item)
        {
            return base.Update<SpeciesDto, SpeciesDto>(id, item);
        }

        public IViewResponse<SpeciesDto> View(int id)
        {
            return base.View<SpeciesDto>(id);
        }
    }
}
