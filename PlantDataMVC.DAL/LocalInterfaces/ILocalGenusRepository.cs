using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMVC.DAL.LocalInterfaces
{

    //public interface ILocalGenusRepository : ILocalGenusRepository<ILocalGenus> { }

    public interface ILocalGenusRepository<T> : ILocalRepository<T>
        where T : ILocalGenus
    {
        /// <summary>
        /// Get single item by Latin name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        T GetItemByLatinName(string latinName);
    }
}
