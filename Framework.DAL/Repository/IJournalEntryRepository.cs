using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.DAL.Entities;

namespace PlantDataMVC.DAL.Interfaces
{
    public interface IJournalEntryRepository : IJournalEntryRepository<JournalEntry> { }

    public interface IJournalEntryRepository<T> : IRepository<T>
        where T: IJournalEntry
    {
    }
}
