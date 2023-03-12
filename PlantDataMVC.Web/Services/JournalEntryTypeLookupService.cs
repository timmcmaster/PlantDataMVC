using Framework.Web.Services;
using MediatR;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantDataMVC.Web.Services
{
    public interface IJournalEntryTypeLookupService: ILookupService<JournalEntryTypeDataModel>
    {
    }

    public class JournalEntryTypeLookupService : LookupService<JournalEntryTypeDataModel>, IJournalEntryTypeLookupService
    {
        public JournalEntryTypeLookupService(IMediator mediator): base(mediator) 
        {
        }
    }
}
