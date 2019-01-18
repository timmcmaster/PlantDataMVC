using Interfaces.DAL.UnitOfWork;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.Services
{
    public class SeedTrayWcfService : WcfService<SeedTray>, ISeedTrayWcfService
    {
        public SeedTrayWcfService(IUnitOfWorkAsync unitOfWork, ISeedTrayService service) : base(unitOfWork, service)
        {
        }

        public ICreateResponse<SeedTrayDto> Create(SeedTrayDto item)
        {
            return base.Create<SeedTrayDto, SeedTrayDto>(item);
        }

        public IDeleteResponse<SeedTrayDto> Delete(int id)
        {
            return base.Delete<SeedTrayDto>(id);
        }

        public IListResponse<SeedTrayDto> List()
        {
            return base.List<SeedTrayDto>();
        }

        public IUpdateResponse<SeedTrayDto> Update(int id, SeedTrayDto item)
        {
            return base.Update<SeedTrayDto, SeedTrayDto>(id, item);
        }

        public IViewResponse<SeedTrayDto> View(int id)
        {
            return base.View<SeedTrayDto>(id);
        }
    }
}
