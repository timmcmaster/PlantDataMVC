using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using PlantDataMVC.DAL.Interfaces;
using PlantDataMVC.DAL.Entities;
using PlantDataMVC.DAL.LocalInterfaces;
using System;

namespace PlantDataMVC.DAL.MappingRepositories
{
    public class PlantStockMappingRepository<TLocalEntity> : MappingRepository<PlantStock,TLocalEntity>, IPlantStockRepository
        where TLocalEntity : ILocalPlantStock
    {

        public PlantStockMappingRepository(ILocalRepository<TLocalEntity> localRepository)
            : base(localRepository)
        {
        }
    }
}
