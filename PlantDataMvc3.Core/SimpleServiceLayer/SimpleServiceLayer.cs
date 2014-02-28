using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlantDataMvc3.Core.Domain.BusinessObjects;
using PlantDataMvc3.Core.ServiceLayer;
using PlantDataMvc3.Core.DataAccess;

namespace PlantDataMvc3.Core.SimpleServiceLayer
{
    public class SimpleServiceLayer : IServiceLayer
    {
        public IBasicDataService<T> GetDataService<T>() where T : DomainEntity
        {
            if (typeof(T) == typeof(Plant))
            {
                return (IBasicDataService<T>)new PlantDataService(UnitOfWorkManager.Instance());
            }
            else if (typeof(T) == typeof(PlantSeed))
            {
                return (IBasicDataService<T>)new PlantSeedDataService(UnitOfWorkManager.Instance());
            }
            else if (typeof(T) == typeof(PlantSeedSite))
            {
                return (IBasicDataService<T>)new PlantSeedSiteDataService(UnitOfWorkManager.Instance());
            }
            else if (typeof(T) == typeof(PlantSeedTray))
            {
                return (IBasicDataService<T>)new PlantSeedTrayDataService(UnitOfWorkManager.Instance());

            }
            else if (typeof(T) == typeof(PlantStockEntry))
            {
                return (IBasicDataService<T>)new PlantStockEntryDataService(UnitOfWorkManager.Instance());

            }
            else if (typeof(T) == typeof(PlantStockTransaction))
            {
                return (IBasicDataService<T>)new PlantStockTransactionDataService(UnitOfWorkManager.Instance());
            }
            else if (typeof(T) == typeof(PlantStockTransactionType))
            {
                return (IBasicDataService<T>)new PlantStockTransactionTypeDataService(UnitOfWorkManager.Instance());
            }
            else if (typeof(T) == typeof(PlantProductType))
            {
                return (IBasicDataService<T>)new PlantProductTypeDataService(UnitOfWorkManager.Instance());
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