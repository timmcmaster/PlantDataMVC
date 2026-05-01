using Framework.Web.Services;
using MediatR;
using PlantData.Web.Blazor.Features.Common.List;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Blazor.Features.StocktakeHeader
{
    public interface IStocktakeHeaderLookupService : ILookupServiceAsync<StocktakeDataModel>
    {
    }

    public class StocktakeHeaderLookupService : LookupServiceAsync<StocktakeDataModel>, IStocktakeHeaderLookupService
    {
        public StocktakeHeaderLookupService(IMediator mediator) : base(mediator)
        {
        }
    }
}
