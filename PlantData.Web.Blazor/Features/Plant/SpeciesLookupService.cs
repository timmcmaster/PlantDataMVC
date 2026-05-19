using Framework.Web.Services;
using MediatR;
using PlantData.Web.Blazor.Features.Common.List;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Blazor.Features.Plant;

public interface ISpeciesLookupService : ILookupServiceAsync<SpeciesDataModel>
{
}

public class SpeciesLookupService : LookupServiceAsync<SpeciesDataModel>, ISpeciesLookupService
{
    public SpeciesLookupService(IMediator mediator) : base(mediator)
    {
    }
}
