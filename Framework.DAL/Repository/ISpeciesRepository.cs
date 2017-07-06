using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.DAL.Entities;

namespace PlantDataMVC.DAL.Interfaces
{
    public interface ISpeciesRepository : ISpeciesRepository<Species>
    {
    }

    public interface ISpeciesRepository<T> : IRepository<T>
        where T: ISpecies
    {
    }
}
