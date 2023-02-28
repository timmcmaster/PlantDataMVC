using Interfaces.Domain.Repository;
using PlantDataMVC.Entities.EntityModels;
using System;

namespace PlantDataMVC.Repository.Interfaces
{
    public interface IProductPriceRepository : IRepositoryAsync<ProductPriceEntityModel>
    {
        ProductPriceEntityModel GetItemByProductPriceListDate(int productTypeId, int priceListId, DateTime effectiveDate);
    }
}
