using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.Services
{
    public class SpeciesWcfService : WcfService<SpeciesDTO, Species>,ISpeciesWcfService
    {
        public SpeciesWcfService(IUnitOfWorkAsync uow, ISpeciesService service): base (uow,service)
        {
        }

    }
}
