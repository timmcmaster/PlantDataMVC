using Framework.Web.Services;
using MediatR;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantDataMVC.Web.Services
{
    public interface ISpeciesLookupService: ILookupService<SpeciesDataModel>
    {
    }

    public class SpeciesLookupService : LookupService<SpeciesDataModel>, ISpeciesLookupService
    {
        public SpeciesLookupService(IMediator mediator): base(mediator) 
        {
        }
    }
}
