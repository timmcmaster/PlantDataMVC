using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using PlantDataMvc3.DAL.Entities;
using PlantDataMvc3.DAL.Interfaces;

namespace PlantDataMvc3.DAL.Repositories
{
    public class SeedTrayRepository : Repository<SeedTray>, ISeedTrayRepository
    {

        public SeedTrayRepository()
            : base()
        {
        }
    }
}
