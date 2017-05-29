using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMvc3.DAL.LocalInterfaces
{
    //public interface ILocalJournalEntryRepository : ILocalJournalEntryRepository<ILocalJournalEntry> { }

    public interface ILocalJournalEntryRepository<T> : ILocalRepository<T>
        where T : ILocalJournalEntry
    {
    }
}
