using Framework.Web.Services;
using MediatR;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Mvc.Services
{
    public interface IProductPriceLookupService : ILookupService<ProductPriceDataModel>
    {
    }

    public class ProductPriceLookupService : LookupService<ProductPriceDataModel>, IProductPriceLookupService
    {
        public ProductPriceLookupService(IMediator mediator) : base(mediator)
        {
        }
    }
}
