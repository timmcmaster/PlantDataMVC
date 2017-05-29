using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using PlantDataMVC.DAL.Interfaces;
using PlantDataMVC.DAL.LocalInterfaces;
using PlantDataMVC.DAL.Entities;
using System;

namespace PlantDataMVC.DAL.MappingRepositories
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
