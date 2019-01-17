using Interfaces.DAL.UnitOfWork;
using Interfaces.Service.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.Services
{
    public class JournalEntryTypeWcfService : WcfService<JournalEntryType>,IJournalEntryTypeWcfService
    {
        public JournalEntryTypeWcfService(IUnitOfWorkAsync uow, IJournalEntryTypeService service): base (uow,service)
        {
        }

        public ICreateResponse<JournalEntryTypeDto> Create(JournalEntryTypeDto item)
        {
            return base.Create<JournalEntryTypeDto, JournalEntryTypeDto>(item);
        }

        public IDeleteResponse<JournalEntryTypeDto> Delete(int id)
        {
            return base.Delete<JournalEntryTypeDto>(id);
        }

        public IListResponse<JournalEntryTypeDto> List()
        {
            return base.List<JournalEntryTypeDto>();
        }

        public IUpdateResponse<JournalEntryTypeDto> Update(int id, JournalEntryTypeDto item)
        {
            return base.Update<JournalEntryTypeDto, JournalEntryTypeDto>(id, item);
        }

        public IViewResponse<JournalEntryTypeDto> View(int id)
        {
            return base.View<JournalEntryTypeDto>(id);
        }
    }
}
