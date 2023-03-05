using Framework.Domain.EF;
using Microsoft.EntityFrameworkCore;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;
using System;
using System.Linq;

namespace PlantDataMVC.Repository.Repositories
{
    public class ProductPriceRepository : EFRepository<ProductPriceEntityModel>, IProductPriceRepository
    {
        public ProductPriceRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public override ProductPriceEntityModel GetItemById(int id)
        {
            var result = DbSet.Include(m => m.ProductType).Include(m => m.PriceListType).Single(m => m.Id == id);
            return result;
        }
        public ProductPriceEntityModel GetItemByProductPriceListDate(int productTypeId, int priceListId, DateTime effectiveDate)
        {
            return this.Queryable(useTracking: false).FirstOrDefault(p => p.ProductTypeId == productTypeId && p.PriceListTypeId == priceListId && p.DateEffective == effectiveDate);
        }
    }
}