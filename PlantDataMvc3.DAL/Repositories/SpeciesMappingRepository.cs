using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using PlantDataMvc3.DAL.Interfaces;
using PlantDataMvc3.DAL.Entities;
using PlantDataMvc3.DAL.LocalInterfaces;
using System;

namespace PlantDataMvc3.DAL.Repositories
{
    public class SpeciesMappingRepository<TLocalEntity> : MappingRepository<Species,TLocalEntity>, ISpeciesRepository
        where TLocalEntity : ILocalSpecies
    {

        public SpeciesMappingRepository(ILocalRepository<TLocalEntity> localRepository)
            : base(localRepository)
        {
        }
    }
}
