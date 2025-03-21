using Framework.Web.Services;
using MediatR;
using PlantData.Web.Blazor.Features.Common.List;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Blazor.Services
{
    public interface IProductTypeLookupService : ILookupService<ProductTypeDataModel>
    {
    }

    public class ProductTypeLookupService : LookupService<ProductTypeDataModel>, IProductTypeLookupService
    {
        public ProductTypeLookupService(IMediator mediator) : base(mediator)
        {
        }
    }
}
