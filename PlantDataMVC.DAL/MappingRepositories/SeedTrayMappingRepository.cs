using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using PlantDataMVC.DAL.Entities;
using PlantDataMVC.DAL.Interfaces;
using PlantDataMVC.DAL.LocalInterfaces;

namespace PlantDataMVC.DAL.MappingRepositories
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
