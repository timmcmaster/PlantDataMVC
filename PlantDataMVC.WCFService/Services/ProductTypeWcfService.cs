using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.Services
{
    public class ProductTypeWcfService : WcfService<ProductType>,IProductTypeWcfService
    {
        public ProductTypeWcfService(IUnitOfWorkAsync uow, IProductTypeService service): base (uow,service)
        {
        }

    }
}
