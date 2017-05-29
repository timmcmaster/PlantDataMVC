using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.DAL.Entities;

namespace PlantDataMVC.DAL.Interfaces
{
    public interface ISeedTrayRepository : ISeedTrayRepository<SeedTray> { }

    public interface ISeedTrayRepository<T> : IRepository<T>
        where T : ISeedTray
    {
    }
}
