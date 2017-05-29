﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.DAL.Entities;

namespace PlantDataMVC.DAL.Interfaces
{
    public interface ISeedBatchRepository : ISeedBatchRepository<SeedBatch> { }

    public interface ISeedBatchRepository<T> : IRepository<T>
        where T : ISeedBatch
    {
    }
}