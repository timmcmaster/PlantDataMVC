using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlantDataMVC.Core.Domain.BusinessObjects;
using PlantDataMVC.Core.ServiceLayer;
using PlantDataMVC.Core.DataAccess;
using PlantDataMVC.DAL.Interfaces;

namespace PlantDataMVC.Core.SimpleServiceLayer
{
    public class SimpleServiceLayer : IServiceLayer
    {
        private IUnitOfWork _uow;

        //Add constructor for constructor dependency injection
        public SimpleServiceLayer(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IBasicDataService<T> GetDataService<T>() where T : DomainEntity
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