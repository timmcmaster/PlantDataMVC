using Framework.Web.Services;
using MediatR;
using PlantData.Web.Blazor.Features.Common.List;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Blazor.Features.ProductPrice;

public interface IProductPriceLookupService : ILookupServiceAsync<ProductPriceDataModel>
{
}

public class ProductPriceLookupService : LookupServiceAsync<ProductPriceDataModel>, IProductPriceLookupService
{
    public ProductPriceLookupService(IMediator mediator) : base(mediator)
    {
    }
}
