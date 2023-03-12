using Framework.Web.Services;
using MediatR;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantDataMVC.Web.Services
{
    public interface ISeedBatchLookupService: ILookupService<SeedBatchDataModel>
    {
    }

    public class SeedBatchLookupService : LookupService<SeedBatchDataModel>, ISeedBatchLookupService
    {
        public SeedBatchLookupService(IMediator mediator): base(mediator) 
        {
        }
    }
}
