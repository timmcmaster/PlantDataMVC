using Framework.Web.Services;
using MediatR;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Mvc.Services
{
    public interface IGenusLookupService : ILookupService<GenusDataModel>
    {
    }

    public class GenusLookupService : LookupService<GenusDataModel>, IGenusLookupService
    {
        public GenusLookupService(IMediator mediator) : base(mediator)
        {
        }
    }
}
