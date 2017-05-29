using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMvc3.DAL.LocalInterfaces
{
    //public interface ILocalSpeciesRepository : ILocalSpeciesRepository<ILocalSpecies> { }

    public interface ILocalSpeciesRepository<T> : ILocalRepository<T>
        where T : ILocalSpecies
    {
    }
}
