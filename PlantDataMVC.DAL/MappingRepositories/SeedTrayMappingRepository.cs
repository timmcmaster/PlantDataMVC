using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using PlantDataMvc3.DAL.Entities;
using PlantDataMvc3.DAL.Interfaces;
using PlantDataMvc3.DAL.LocalInterfaces;

namespace PlantDataMvc3.DAL.MappingRepositories
{
    public class SeedTrayMappingRepository<TLocalEntity> : MappingRepository<SeedTray,TLocalEntity>, ISeedTrayRepository
        where TLocalEntity : ILocalSeedTray
    {

        public SeedTrayMappingRepository(ILocalRepository<TLocalEntity> localRepository)
            : base(localRepository)
        {
        }
    }
}
