using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.Services
{
    public class PlantStockWcfService : WcfService<PlantStockDTO, PlantStock>,IPlantStockWcfService
    {
        public PlantStockWcfService(IUnitOfWorkAsync uow, IPlantStockService service): base (uow,service)
        {
        }

    }
}
