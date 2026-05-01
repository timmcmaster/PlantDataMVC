using Framework.Web.Services;
using MediatR;
using PlantData.Web.Blazor.Features.Common.List;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Blazor.Features.PriceListType
{
    public interface IPriceListTypeLookupService : ILookupServiceAsync<PriceListTypeDataModel>
    {
    }

    public class PriceListTypeLookupService : LookupServiceAsync<PriceListTypeDataModel>, IPriceListTypeLookupService
    {
        public PriceListTypeLookupService(IMediator mediator) : base(mediator)
        {
        }
    }
}
