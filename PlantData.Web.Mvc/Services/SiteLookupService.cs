using Framework.Web.Services;
using MediatR;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Mvc.Services
{
    public interface ISiteLookupService : ILookupService<SiteDataModel>
    {
    }

    public class SiteLookupService : LookupService<SiteDataModel>, ISiteLookupService
    {
        public SiteLookupService(IMediator mediator) : base(mediator)
        {
        }
    }
}
