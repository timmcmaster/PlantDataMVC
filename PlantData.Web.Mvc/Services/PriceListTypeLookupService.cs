using Framework.Web.Services;
using MediatR;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Mvc.Services
{
    public interface IPriceListTypeLookupService : ILookupService<PriceListTypeDataModel>
    {
    }

    public class PriceListTypeLookupService : LookupService<PriceListTypeDataModel>, IPriceListTypeLookupService
    {
        public PriceListTypeLookupService(IMediator mediator) : base(mediator)
        {
        }
    }
}
