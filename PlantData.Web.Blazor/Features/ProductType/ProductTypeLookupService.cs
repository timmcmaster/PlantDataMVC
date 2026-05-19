using Framework.Web.Services;
using MediatR;
using PlantData.Web.Blazor.Features.Common.List;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Blazor.Features.ProductType;

public interface IProductTypeLookupService : ILookupServiceAsync<ProductTypeDataModel>
{
}

public class ProductTypeLookupService : LookupServiceAsync<ProductTypeDataModel>, IProductTypeLookupService
{
    public ProductTypeLookupService(IMediator mediator) : base(mediator)
    {
    }
}
