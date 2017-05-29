using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using PlantDataMvc3.DAL.Interfaces;
using PlantDataMvc3.DAL.Entities;
using PlantDataMvc3.DAL.LocalInterfaces;
using System;

namespace PlantDataMvc3.DAL.MappingRepositories
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
