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
    public interface IPlantDataService: IBasicDataService<Plant>
    {
    }

    [ServiceContract]
    public interface IPlantProductTypeDataService : IBasicDataService<PlantProductType>
    {
    }

    [ServiceContract]
    public interface IPlantSeedDataService : IBasicDataService<PlantSeed>
    {
    }

    [ServiceContract]
    public interface IPlantSeedSiteDataService : IBasicDataService<PlantSeedSite>
    {
    }

    [ServiceContract]
    public interface IPlantSeedTrayDataService : IBasicDataService<PlantSeedTray>
    {
    }

    [ServiceContract]
    public interface IPlantStockEntryDataService : IBasicDataService<PlantStockEntry>
    {
    }

    [ServiceContract]
    public interface IPlantStockTransactionDataService : IBasicDataService<PlantStockTransaction>
    {
    }

    [ServiceContract]
    public interface IPlantStockTransactionTypeDataService : IBasicDataService<PlantStockTransactionType>
    {
    }
}
