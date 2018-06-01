using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PlantDataMVC.Service.ServiceContracts
{
    [ServiceContract]
    public interface IPlantProductTypeDataService : IDataServiceBase<PlantProductType>
    {
    }

    [ServiceContract]
    public interface IPlantSeedDataService : IDataServiceBase<PlantSeed>
    {
    }

    [ServiceContract]
    public interface IPlantSeedSiteDataService : IDataServiceBase<PlantSeedSite>
    {
    }

    [ServiceContract]
    public interface IPlantSeedTrayDataService : IDataServiceBase<PlantSeedTray>
    {
    }

    [ServiceContract]
    public interface IPlantStockEntryDataService : IDataServiceBase<PlantStockEntry>
    {
    }

    [ServiceContract]
    public interface IPlantStockTransactionDataService : IDataServiceBase<PlantStockTransaction>
    {
    }

    [ServiceContract]
    public interface IPlantStockTransactionTypeDataService : IDataServiceBase<PlantStockTransactionType>
    {
    }
}
