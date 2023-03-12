using Framework.Web.Services;
using MediatR;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantDataMVC.Web.Services
{
    public interface IPriceListTypeLookupService: ILookupService<PriceListTypeDataModel>
    {
    }

    public class PriceListTypeLookupService : LookupService<PriceListTypeDataModel>, IPriceListTypeLookupService
    {
        public PriceListTypeLookupService(IMediator mediator): base(mediator) 
        {
        }
    }
}
