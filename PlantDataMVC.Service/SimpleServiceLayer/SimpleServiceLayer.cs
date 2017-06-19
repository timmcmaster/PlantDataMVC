using Framework.Service.ServiceLayer;
using Framework.DAL.UnitOfWork;
using Framework.Domain;
using PlantDataMVC.Domain.Entities;

namespace PlantDataMVC.Service.SimpleServiceLayer
{
    public class SimpleServiceLayer : IServiceLayer
    {
        private IUnitOfWork _uow;

        //Add constructor for constructor dependency injection
        public SimpleServiceLayer(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IBasicDataService<T> GetDataService<T>() where T : IDomainEntity
        {
            if (typeof(T) == typeof(Plant))
            {
                return (IBasicDataService<T>)new PlantDataService(_uow);
            }
            else if (typeof(T) == typeof(PlantSeed))
            {
                return (IBasicDataService<T>)new PlantSeedDataService(_uow);
            }
            else if (typeof(T) == typeof(PlantSeedSite))
            {
                return (IBasicDataService<T>)new PlantSeedSiteDataService(_uow);
            }
            else if (typeof(T) == typeof(PlantSeedTray))
            {
                return (IBasicDataService<T>)new PlantSeedTrayDataService(_uow);

            }
            else if (typeof(T) == typeof(PlantStockEntry))
            {
                return (IBasicDataService<T>)new PlantStockEntryDataService(_uow);

            }
            else if (typeof(T) == typeof(PlantStockTransaction))
            {
                return (IBasicDataService<T>)new PlantStockTransactionDataService(_uow);
            }
            else if (typeof(T) == typeof(PlantStockTransactionType))
            {
                return (IBasicDataService<T>)new PlantStockTransactionTypeDataService(_uow);
            }
            else if (typeof(T) == typeof(PlantProductType))
            {
                return (IBasicDataService<T>)new PlantProductTypeDataService(_uow);
            }
            //else if (typeof(T) == typeof(PlantPriceListType))
            //{
            //    return (IBasicDataService<T>)new PlantPriceListTypeDataService();
            //}
            //else if (typeof(T) == typeof(PlantProductPrice))
            //{
            //    return (IBasicDataService<T>)new PlantProductPriceDataService();
            //}
            else
            {
                return null;
            }
        }
    }
}