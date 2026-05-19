using Framework.Web.Services;
using MediatR;
using PlantData.Web.Blazor.Features.Common.List;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Blazor.Features.SeedBatch;

public interface ISeedBatchLookupService : ILookupServiceAsync<SeedBatchDataModel>
{
}

public class SeedBatchLookupService : LookupServiceAsync<SeedBatchDataModel>, ISeedBatchLookupService
{
    public SeedBatchLookupService(IMediator mediator) : base(mediator)
    {
    }
}
