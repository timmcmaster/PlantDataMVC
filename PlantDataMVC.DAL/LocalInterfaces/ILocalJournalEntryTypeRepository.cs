using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using PlantDataMvc3.DAL.Entities;

namespace PlantDataMvc3.DAL.LocalInterfaces
{
    //public interface ILocalJournalEntryTypeRepository : ILocalJournalEntryTypeRepository<ILocalJournalEntryType> { }

    public interface ILocalJournalEntryTypeRepository<T> : ILocalRepository<T>
        where T : ILocalJournalEntryType
    {
    }
}
