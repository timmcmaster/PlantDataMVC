using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMvc3.DAL.Entities;

namespace PlantDataMvc3.DAL.Interfaces
{
    public interface IGenusRepository : IGenusRepository<Genus> { }

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
