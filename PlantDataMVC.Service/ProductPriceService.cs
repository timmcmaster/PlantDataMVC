using Framework.Service;
using Interfaces.Service;
using Microsoft.VisualBasic;
using PlantDataMVC.Entities.EntityModels;
using PlantDataMVC.Repository.Interfaces;
using System;

namespace PlantDataMVC.Service
{
    public interface IProductPriceService : IService<ProductPriceEntityModel>
    {
        ProductPriceEntityModel GetItemByProductPriceListDate(int productTypeId, int priceListId, DateTime effectiveDate);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class ProductPriceService : Service<ProductPriceEntityModel>, IProductPriceService
    {
        private readonly IProductPriceRepository _repository;
        public ProductPriceService(IProductPriceRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public ProductPriceEntityModel GetItemByProductPriceListDate(int productTypeId, int priceListId, DateTime effectiveDate)
        {
            return _repository.GetItemByProductPriceListDate(productTypeId, priceListId, effectiveDate);
        }
    }
}