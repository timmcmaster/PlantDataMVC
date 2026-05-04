using Framework.Web.Services;
using MediatR;
using PlantData.Web.Blazor.Features.Common.List;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Blazor.Features.TransactionType
{
    public interface IJournalEntryTypeLookupService : ILookupServiceAsync<JournalEntryTypeDataModel>
    {
    }

    public class JournalEntryTypeLookupService : LookupServiceAsync<JournalEntryTypeDataModel>, IJournalEntryTypeLookupService
    {
        public JournalEntryTypeLookupService(IMediator mediator) : base(mediator)
        {
        }
    }
}
