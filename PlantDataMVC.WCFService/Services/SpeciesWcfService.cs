﻿using Framework.WcfService;
using Interfaces.DAL.UnitOfWork;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.Services
{
    public class SpeciesWcfService : WcfService<Species>, ISpeciesWcfService
    {
        //public SpeciesWcfService(IUnitOfWorkAsync unitOfWork, ISpeciesService service): base (unitOfWork,service)
        public SpeciesWcfService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
        }

        #region ISpeciesWcfService Members
        public ICreateResponse<SpeciesDto> Create(SpeciesDto item)
        {
            return base.Create<SpeciesDto, SpeciesDto>(item);
        }

        public IDeleteResponse<SpeciesDto> Delete(int id)
        {
            return base.Delete<SpeciesDto>(id);
        }

        public IListResponse<SpeciesInListDto> List()
        {
            return base.List<SpeciesInListDto>();
        }

        public IUpdateResponse<SpeciesDto> Update(int id, SpeciesDto item)
        {
            return base.Update<SpeciesDto, SpeciesDto>(id, item);
        }

        public IViewResponse<SpeciesDto> View(int id)
        {
            return base.View<SpeciesDto>(id);
        }
        #endregion
    }
}