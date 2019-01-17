using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.Services
{
    public class SiteWcfService : WcfService<Site>, ISiteWcfService
    {
        public SiteWcfService(IUnitOfWorkAsync uow, ISiteService service) : base(uow, service)
        {
        }

    }
}
