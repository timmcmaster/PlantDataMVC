using Interfaces.DAL.UnitOfWork;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.Services
{
    public class SiteWcfService : WcfService<Site>, ISiteWcfService
    {
        public SiteWcfService(IUnitOfWorkAsync uow, ISiteService service) : base(uow, service)
        {
        }

        public ICreateResponse<SiteDto> Create(SiteDto item)
        {
            return base.Create<SiteDto, SiteDto>(item);
        }

        public IDeleteResponse<SiteDto> Delete(int id)
        {
            return base.Delete<SiteDto>(id);
        }

        public IListResponse<SiteDto> List()
        {
            return base.List<SiteDto>();
        }

        public IUpdateResponse<SiteDto> Update(int id, SiteDto item)
        {
            return base.Update<SiteDto, SiteDto>(id, item);
        }

        public IViewResponse<SiteDto> View(int id)
        {
            return base.View<SiteDto>(id);
        }
    }
}
