﻿using System.Data.Entity;
using PlantDataMVC.DAL.EF.Entities;
using PlantDataMVC.DAL.LocalInterfaces;

namespace PlantDataMVC.DAL.EF.Repositories
{
    public class EFPlantStockRepository : EFRepositoryBase<PlantStock>, ILocalPlantStockRepository<PlantStock>
    {
        public EFPlantStockRepository(DbContext context)
            : base(context)
        {
            //this.DefaultOrderBy = (q => q.OrderBy(ps => ps.Species.Genus.LatinName).ThenBy(ps => ps.Species.LatinName));
        }
    }
}