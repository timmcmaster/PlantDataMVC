using Framework.WcfService;
using Interfaces.DAL.UnitOfWork;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.Services
{
    public class ProductTypeWcfService : WcfService<ProductType>, IProductTypeWcfService
    {
        //public ProductTypeWcfService(IUnitOfWorkAsync unitOfWork, IProductTypeService service): base (unitOfWork,service)
        public ProductTypeWcfService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
        }

        #region IProductTypeWcfService Members
        public ICreateResponse<ProductTypeDto> Create(ProductTypeDto item)
        {
            return base.Create<ProductTypeDto, ProductTypeDto>(item);
        }

        public IDeleteResponse<ProductTypeDto> Delete(int id)
        {
            return base.Delete<ProductTypeDto>(id);
        }

        public IListResponse<ProductTypeDto> List()
        {
            return base.List<ProductTypeDto>();
        }

        public IUpdateResponse<ProductTypeDto> Update(int id, ProductTypeDto item)
        {
            return base.Update<ProductTypeDto, ProductTypeDto>(id, item);
        }

        public IViewResponse<ProductTypeDto> View(int id)
        {
            return base.View<ProductTypeDto>(id);
        }
        #endregion
    }
}