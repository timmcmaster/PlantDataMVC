using Framework.Web.Services;
using MediatR;
using PlantData.Web.Blazor.Features.Common.List;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Blazor.Features.SeedTray
{
    public interface ISeedTrayLookupService : ILookupServiceAsync<SeedTrayDataModel>
    {
    }

    public class SeedTrayLookupService : LookupServiceAsync<SeedTrayDataModel>, ISeedTrayLookupService
    {
        public SeedTrayLookupService(IMediator mediator) : base(mediator)
        {
        }
    }
}
