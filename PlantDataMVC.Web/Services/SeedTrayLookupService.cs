using Framework.Web.Services;
using MediatR;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantDataMVC.Web.Services
{
    public interface ISeedTrayLookupService: ILookupService<SeedTrayDataModel>
    {
    }

    public class SeedTrayLookupService : LookupService<SeedTrayDataModel>, ISeedTrayLookupService
    {
        public SeedTrayLookupService(IMediator mediator): base(mediator) 
        {
        }
    }
}
