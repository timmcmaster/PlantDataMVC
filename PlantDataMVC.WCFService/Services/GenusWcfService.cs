using Framework.Service.Responses;
using Interfaces.DAL.UnitOfWork;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Dtos;
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

        public ICreateResponse<GenusDto> Create(CreateUpdateGenusDto item)
        {
            return base.Create<CreateUpdateGenusDto,GenusDto>(item);
        }

        public IDeleteResponse<GenusDto> Delete(int id)
        {
            return base.Delete<GenusDto>(id);
        }

        public IListResponse<GenusDto> List()
        {
            return base.List<GenusDto>();
        }

        public IUpdateResponse<GenusDto> Update(int id, CreateUpdateGenusDto item)
        {
            return base.Update<CreateUpdateGenusDto, GenusDto>(id, item);
        }

        public IViewResponse<GenusDto> View(int id)
        {
            return base.View<GenusDto>(id);
        }
    }
}
