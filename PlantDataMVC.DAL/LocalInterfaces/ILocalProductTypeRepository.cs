using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMvc3.DAL.LocalInterfaces
{
    //public interface ILocalProductTypeRepository : ILocalProductTypeRepository<ILocalProductType> { }

    public interface ILocalProductTypeRepository<T> : ILocalRepository<T>
        where T : ILocalProductType
    {
    }
}
