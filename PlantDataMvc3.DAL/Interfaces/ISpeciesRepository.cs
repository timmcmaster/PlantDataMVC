using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMvc3.DAL.Entities;

namespace PlantDataMvc3.DAL.Interfaces
{
    public interface ISpeciesRepository : ISpeciesRepository<Species> { }

    public interface ISpeciesRepository<T> : IRepository<T>
        where T : ISpecies
    {
    }
}
