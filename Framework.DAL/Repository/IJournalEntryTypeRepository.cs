using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.DAL.Entities;

namespace PlantDataMVC.DAL.Interfaces
{
    public interface IJournalEntryTypeRepository : IJournalEntryTypeRepository<JournalEntryType> { }

    public interface IJournalEntryTypeRepository<T> : IRepository<T>
        where T: IJournalEntryType
    {
    }
}
