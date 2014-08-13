using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMvc3.DAL.Entities;

namespace PlantDataMvc3.DAL.Interfaces
{
    /// <summary>
    /// The specific repository interface exposed from the DAL to the Business Layer.
    /// Implemented to ...
    /// </summary>
    public interface IGenusRepository : IGenusRepository<Genus> { }

    /// <summary>
    /// A derived version of the generic repository.
    /// Allows us to add new methods that are specific to the Genus class
    /// while still using the type param to allow typesafe methods  
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenusRepository<T>: IRepository<T>
        where T: IGenus
    {
        /// <summary>
        /// Get single item by Latin name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        T GetItemByLatinName(string latinName);
    }
}
