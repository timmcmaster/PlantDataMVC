using Interfaces.DAL.UnitOfWork;
using PlantDataMVC.DTO.Entities;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Service;
using PlantDataMVC.WCFService.ServiceContracts;

namespace PlantDataMVC.WCFService.Services
{
    public class JournalEntryTypeWcfService : WcfService<JournalEntryTypeDTO, JournalEntryType>,IJournalEntryTypeWcfService
    {
        public JournalEntryTypeWcfService(IUnitOfWorkAsync uow, IJournalEntryTypeService service): base (uow,service)
        {
        }

    }
}
