using Framework.Web.Services;
using MediatR;
using PlantData.Web.Blazor.Features.Common.List;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Blazor.Features.Site
{
    public interface ISiteLookupService : ILookupServiceAsync<SiteDataModel>
    {
    }

    public class SiteLookupService : LookupServiceAsync<SiteDataModel>, ISiteLookupService
    {
        public SiteLookupService(IMediator mediator) : base(mediator)
        {
        }
    }
}
