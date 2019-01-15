using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.Services
{
    public class SeedBatchWcfService : WcfService<SeedBatchDTO, SeedBatch>,ISeedBatchWcfService
    {
        public SeedBatchWcfService(IUnitOfWorkAsync uow, ISeedBatchService service): base (uow,service)
        {
        }

    }
}
