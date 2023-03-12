using Framework.Web.Services;
using MediatR;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantDataMVC.Web.Services
{
    public interface IProductPriceLookupService: ILookupService<ProductPriceDataModel>
    {
    }

    public class ProductPriceLookupService : LookupService<ProductPriceDataModel>, IProductPriceLookupService
    {
        public ProductPriceLookupService(IMediator mediator): base(mediator) 
        {
        }
    }
}
