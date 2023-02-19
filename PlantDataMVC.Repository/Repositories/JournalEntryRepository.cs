﻿using Framework.Domain.EF;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;
using PlantDataMVC.Repository.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlantDataMVC.Repository.Repositories
{
    public class JournalEntryRepository : EFRepository<JournalEntryEntityModel>, IJournalEntryRepository
    {
        public JournalEntryRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public override JournalEntryEntityModel GetItemById(int id)
        {
            var result = DbSet.Include(m => m.JournalEntryType).Single(m => m.Id == id);
            return result;
        }

        public int GetStockCountForSpeciesAndProduct(int speciesId, int productTypeId)
        {
            var stockCount = GetStockCounts(speciesId, productTypeId).FirstOrDefault();
            return stockCount?.QuantityInStock ?? 0;
        }

        public List<JournalEntryStockSummaryModel> GetStockCounts(int? speciesId, int? productTypeId)
        {
            var stockSummaries = new List<JournalEntryStockSummaryModel>();

            var groups = DbSet
                .Include(m => m.Species).ThenInclude(m => m.Genus)
                .Include(m => m.ProductType)
                .Include(m => m.JournalEntryType)
                .GroupBy(je => new { je.SpeciesId, je.ProductTypeId })
                .Select(g => new JournalEntryStockSummaryModel()
                {
                    SpeciesId = g.Key.SpeciesId,
                    ProductTypeId = g.Key.ProductTypeId,
                    GenusName = g.FirstOrDefault().Species.Genus.LatinName,
                    SpeciesName = g.FirstOrDefault().Species.SpecificName,
                    ProductTypeName = g.FirstOrDefault().ProductType.Name,
                    QuantityInStock = g.Sum(je => je.Quantity * je.JournalEntryType.Effect)
                });

            if (speciesId.HasValue)
                groups = groups.Where(g => g.SpeciesId == speciesId.Value);

            if (productTypeId.HasValue)
                groups = groups.Where(g => g.ProductTypeId == productTypeId.Value);

            stockSummaries.AddRange( groups.ToList());

            return stockSummaries;
        }
    }
}