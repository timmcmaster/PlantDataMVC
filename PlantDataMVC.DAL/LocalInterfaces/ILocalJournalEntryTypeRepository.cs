using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using PlantDataMVC.DAL.Entities;

namespace PlantDataMVC.DAL.LocalInterfaces
{
    //public interface ILocalJournalEntryTypeRepository : ILocalJournalEntryTypeRepository<ILocalJournalEntryType> { }

    public interface ILocalJournalEntryTypeRepository<T> : ILocalRepository<T>
        where T : ILocalJournalEntryType
    {
    }
}
