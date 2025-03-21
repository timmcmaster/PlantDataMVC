using Framework.Web.Services;
using MediatR;
using PlantData.Web.Blazor.Features.Common.List;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Blazor.Services
{
    public interface ISeedTrayLookupService : ILookupService<SeedTrayDataModel>
    {
    }

    public class SeedTrayLookupService : LookupService<SeedTrayDataModel>, ISeedTrayLookupService
    {
        public SeedTrayLookupService(IMediator mediator) : base(mediator)
        {
        }
    }
}
