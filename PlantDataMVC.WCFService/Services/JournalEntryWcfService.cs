using Interfaces.DAL.UnitOfWork;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.Services
{
    public class JournalEntryWcfService : WcfService<JournalEntry>, IJournalEntryWcfService
    {
        public JournalEntryWcfService(IUnitOfWorkAsync uow, IJournalEntryService service): base (uow,service)
        {
        }

        public ICreateResponse<JournalEntryDto> Create(JournalEntryDto item)
        {
            return base.Create<JournalEntryDto, JournalEntryDto>(item);
        }

        public IDeleteResponse<JournalEntryDto> Delete(int id)
        {
            return base.Delete<JournalEntryDto>(id);
        }

        public IListResponse<JournalEntryDto> List()
        {
            return base.List<JournalEntryDto>();
        }

        public IUpdateResponse<JournalEntryDto> Update(int id, JournalEntryDto item)
        {
            return base.Update<JournalEntryDto, JournalEntryDto>(id, item);
        }

        public IViewResponse<JournalEntryDto> View(int id)
        {
            return base.View<JournalEntryDto>(id);
        }
    }
}
