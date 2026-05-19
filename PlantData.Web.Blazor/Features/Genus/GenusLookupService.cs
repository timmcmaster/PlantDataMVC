using Framework.Web.Services;
using MediatR;
using PlantData.Web.Blazor.Features.Common.List;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Blazor.Features.Genus;

public interface IGenusLookupService : ILookupServiceAsync<GenusDataModel>
{
}

public class GenusLookupService : LookupServiceAsync<GenusDataModel>, IGenusLookupService
{
    public GenusLookupService(IMediator mediator) : base(mediator)
    {
    }
}
