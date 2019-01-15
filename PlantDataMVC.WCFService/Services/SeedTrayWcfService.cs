using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.Services
{
    public class SeedTrayWcfService : WcfService<SeedTrayDTO, SeedTray>,ISeedTrayWcfService
    {
        public SeedTrayWcfService(IUnitOfWorkAsync uow, ISeedTrayService service): base (uow,service)
        {
        }

    }
}
