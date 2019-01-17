using Interfaces.DAL.UnitOfWork;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.Services
{
    public class PlantStockWcfService : WcfService<PlantStock>, IPlantStockWcfService
    {
        public PlantStockWcfService(IUnitOfWorkAsync uow, IPlantStockService service): base (uow,service)
        {
        }

        public ICreateResponse<PlantStockDto> Create(PlantStockDto item)
        {
            return base.Create<PlantStockDto, PlantStockDto>(item);
        }

        public IDeleteResponse<PlantStockDto> Delete(int id)
        {
            return base.Delete<PlantStockDto>(id);
        }

        public IListResponse<PlantStockDto> List()
        {
            return base.List<PlantStockDto>();
        }

        public IUpdateResponse<PlantStockDto> Update(int id, PlantStockDto item)
        {
            return base.Update<PlantStockDto, PlantStockDto>(id, item);
        }

        public IViewResponse<PlantStockDto> View(int id)
        {
            return base.View<PlantStockDto>(id);
        }
    }
}
