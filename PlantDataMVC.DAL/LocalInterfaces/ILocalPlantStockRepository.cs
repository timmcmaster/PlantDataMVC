﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlantDataMVC.DAL.LocalInterfaces
{
    //public interface ILocalPlantStockRepository : ILocalPlantStockRepository<ILocalPlantStock> { }

    public interface ILocalPlantStockRepository<T> : ILocalRepository<T>
        where T : ILocalPlantStock
    {
    }
}