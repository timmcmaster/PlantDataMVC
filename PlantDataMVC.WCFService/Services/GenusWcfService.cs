using Interfaces.DAL.UnitOfWork;
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
    }
}
