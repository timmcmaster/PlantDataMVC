using Framework.Service.Responses;
using Interfaces.DAL.UnitOfWork;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.Services
{
    public class GenusWcfService : WcfService<Genus>, IGenusWcfService
    {
        public GenusWcfService(IUnitOfWorkAsync uow, IGenusService service) : base(uow, service)
        {
        }

        public ICreateResponse<GenusDto> Create(GenusDto item)
        {
            return base.Create<GenusDto,GenusDto>(item);
        }

        public IDeleteResponse<GenusDto> Delete(int id)
        {
            return base.Delete<GenusDto>(id);
        }

        public IListResponse<GenusDto> List()
        {
            return base.List<GenusDto>();
        }

        public IUpdateResponse<GenusDto> Update(int id, GenusDto item)
        {
            return base.Update<GenusDto, GenusDto>(id, item);
        }

        public IViewResponse<GenusDto> View(int id)
        {
            return base.View<GenusDto>(id);
        }
    }
}
