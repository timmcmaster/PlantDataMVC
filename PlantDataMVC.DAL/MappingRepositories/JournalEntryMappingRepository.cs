using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using PlantDataMvc3.DAL.Interfaces;
using PlantDataMvc3.DAL.LocalInterfaces;
using PlantDataMvc3.DAL.Entities;
using System;

namespace PlantDataMvc3.DAL.MappingRepositories
{
    public class JournalEntryMappingRepository<TLocalEntity> : MappingRepository<JournalEntry, TLocalEntity>, IJournalEntryRepository
        where TLocalEntity : ILocalJournalEntry
    {

        public JournalEntryMappingRepository(ILocalJournalEntryRepository<TLocalEntity> localRepository)
            : base(localRepository)
        {
        }
    }
}
