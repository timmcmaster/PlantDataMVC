using Framework.WcfService;
using Interfaces.DAL.UnitOfWork;
using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.Services
{
    public class JournalEntryWcfService : WcfService<JournalEntry>, IJournalEntryWcfService
    {
        //public JournalEntryWcfService(IUnitOfWorkAsync unitOfWork, IJournalEntryService service) : base(unitOfWork, service)
        public JournalEntryWcfService(IUnitOfWorkAsync unitOfWork) : base(unitOfWork)
        {
        }

        #region IJournalEntryWcfService Members
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
        #endregion
    }
}