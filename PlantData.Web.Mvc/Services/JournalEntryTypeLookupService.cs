using Framework.Web.Services;
using MediatR;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Mvc.Services
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
