using Framework.Web.Services;
using MediatR;
using PlantData.Web.Blazor.Features.Common.List;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Blazor.Services
{
    public interface IJournalEntryTypeLookupService : ILookupService<JournalEntryTypeDataModel>
    {
    }

    public class JournalEntryTypeLookupService : LookupService<JournalEntryTypeDataModel>, IJournalEntryTypeLookupService
    {
        public JournalEntryTypeLookupService(IMediator mediator) : base(mediator)
        {
        }
    }
}
