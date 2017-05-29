using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMVC.DAL.LocalInterfaces
{
    //public interface ILocalSeedBatchRepository : ILocalSeedBatchRepository<ILocalSeedBatch> { }

    public interface ILocalSeedBatchRepository<T> : ILocalRepository<T>
        where T : ILocalSeedBatch
    {
    }
}
