using Framework.Web.Services;
using MediatR;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantDataMVC.Web.Services
{
    public interface IProductTypeLookupService: ILookupService<ProductTypeDataModel>
    {
    }

    public class ProductTypeLookupService : LookupService<ProductTypeDataModel>, IProductTypeLookupService
    {
        public ProductTypeLookupService(IMediator mediator): base(mediator) 
        {
        }
    }
}
