using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlantDataMVC.DAL.Entities;

namespace PlantDataMVC.DAL.Interfaces
{
    public interface IPlantStockRepository : IPlantStockRepository<PlantStock> { }

    public interface IPlantStockRepository<T> : IRepository<T>
        where T : IPlantStock
    {
    }
}
