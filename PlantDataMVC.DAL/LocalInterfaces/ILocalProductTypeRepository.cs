using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMVC.DAL.LocalInterfaces
{
    //public interface ILocalProductTypeRepository : ILocalProductTypeRepository<ILocalProductType> { }

    public interface ILocalProductTypeRepository<T> : ILocalRepository<T>
        where T : ILocalProductType
    {
    }
}
