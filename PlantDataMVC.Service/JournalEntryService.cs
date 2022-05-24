﻿using Framework.Service;
using Interfaces.Service;
using PlantDataMVC.Entities.Models;
using PlantDataMVC.Repository.Interfaces;

namespace PlantDataMVC.Service
{
    public interface IJournalEntryService : IService<JournalEntry>
    {
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class JournalEntryService : Service<JournalEntry>, IJournalEntryService
    {
        public JournalEntryService(IJournalEntryRepository repository) : base(repository)
        {
        }
    }
}