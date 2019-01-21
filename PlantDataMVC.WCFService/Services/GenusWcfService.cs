using Framework.WcfService;
using Interfaces.DAL.UnitOfWork;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.Services
{
    public class GenusWcfService : WcfService<Genus>, IGenusWcfService
    {
        ///public GenusWcfService(IUnitOfWorkAsync unitOfWork, IGenusService service) : base(unitOfWork, service)
        public GenusWcfService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
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

        public IListResponse<GenusInListDto> List()
        {
            return base.List<GenusInListDto>();
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
