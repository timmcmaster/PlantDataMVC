using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMvc3.DAL.LocalInterfaces
{
    //public interface ILocalSeedTrayRepository : ILocalSeedTrayRepository<ILocalSeedTray> { }

    public interface ILocalSeedTrayRepository<T> : ILocalRepository<T>
        where T : ILocalSeedTray
    {
    }
}
