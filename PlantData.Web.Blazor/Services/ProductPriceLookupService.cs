using Framework.Web.Services;
using MediatR;
using PlantData.Web.Blazor.Features.Common.List;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Blazor.Services
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
