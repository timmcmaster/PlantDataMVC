using Framework.Web.Services;
using MediatR;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Mvc.Services
{
    public interface ISaleEventLookupService : ILookupService<SaleEventDataModel>
    {
    }

    public class SaleEventLookupService : LookupService<SaleEventDataModel>, ISaleEventLookupService
    {
        public SaleEventLookupService(IMediator mediator) : base(mediator)
        {
        }
    }
}
