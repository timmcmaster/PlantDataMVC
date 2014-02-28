﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMvc3.DAL.Entities;

namespace PlantDataMvc3.DAL.Interfaces
{
    public interface ISeedBatchRepository : ISeedBatchRepository<SeedBatch> { }

    public interface ISeedBatchRepository<T> : IRepository<T>
        where T : ISeedBatch
    {
    }
}
