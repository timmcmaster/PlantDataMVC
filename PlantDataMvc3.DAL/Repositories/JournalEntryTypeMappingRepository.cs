using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using PlantDataMvc3.DAL.Interfaces;
using PlantDataMvc3.DAL.Entities;
using PlantDataMvc3.DAL.LocalInterfaces;
using System;

namespace PlantDataMvc3.DAL.Repositories
{
    public class JournalEntryTypeMappingRepository<TLocalEntity> : MappingRepository<JournalEntryType,TLocalEntity>, IJournalEntryTypeRepository
        where TLocalEntity : ILocalJournalEntryType
    {

        public JournalEntryTypeMappingRepository(ILocalJournalEntryTypeRepository<TLocalEntity> localRepository)
            : base(localRepository)
        {
        }
    }
}
