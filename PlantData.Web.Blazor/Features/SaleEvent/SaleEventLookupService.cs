using Framework.Web.Services;
using MediatR;
using PlantData.Web.Blazor.Features.Common.List;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Blazor.Features.SaleEvent
{
    public interface ISaleEventLookupService : ILookupServiceAsync<SaleEventDataModel>
    {
    }

    public class SaleEventLookupService : LookupServiceAsync<SaleEventDataModel>, ISaleEventLookupService
    {
        public SaleEventLookupService(IMediator mediator) : base(mediator)
        {
        }
    }
}
