using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.Services
{
    public class JournalEntryWcfService : WcfService<JournalEntryDTO, JournalEntry>,IJournalEntryWcfService
    {
        public JournalEntryWcfService(IUnitOfWorkAsync uow, IJournalEntryService service): base (uow,service)
        {
        }

    }
}
