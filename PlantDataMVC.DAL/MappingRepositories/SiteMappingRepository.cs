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
    public class SiteMappingRepository<TLocalEntity> : MappingRepository<Site,TLocalEntity>, ISiteRepository
        where TLocalEntity : ILocalSite
    {

        public SiteMappingRepository(ILocalRepository<TLocalEntity> localRepository)
            : base(localRepository)
        {
        }
    }
}
