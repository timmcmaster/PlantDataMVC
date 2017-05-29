using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.DAL.Entities;

namespace PlantDataMVC.DAL.Interfaces
{
    public interface IProductTypeRepository : IProductTypeRepository<ProductType> { }

    public interface IProductTypeRepository<T> : IRepository<T>
        where T: IProductType
    {
    }
}
