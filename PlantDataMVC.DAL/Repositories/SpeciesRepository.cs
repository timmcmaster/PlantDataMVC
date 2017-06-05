﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using PlantDataMvc3.DAL.Interfaces;
using PlantDataMvc3.DAL.Entities;
using System;

namespace PlantDataMvc3.DAL.Repositories
{
    public class SpeciesRepository : Repository<Species>, ISpeciesRepository
    {

        public SpeciesRepository()
            : base()
        {
        }
    }
}