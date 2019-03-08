﻿using Common.Logging;
using Framework.Service;
using Interfaces.Domain.Repository;
using Interfaces.Service;
using PlantDataMVC.Entities.Models;

namespace PlantDataMVC.Service
{
    public interface ISeedBatchService : IService<SeedBatch>
    {
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class SeedBatchService : Service<SeedBatch>, ISeedBatchService
    {
        private static readonly ILog _log = LogManager.GetLogger<SeedBatchService>();

        public SeedBatchService(IRepositoryAsync<SeedBatch> repository) : base(repository)
        {
        }
    }
}