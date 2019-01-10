using Framework.Service.Entities;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;

namespace PlantDataMVC.Service.ServiceContracts
{
    [ServiceKnownType("GetKnownTypes", typeof(PlantStockTransactionDSHelper))]
    [ServiceContract]
    public interface IPlantStockTransactionDataService : IDataServiceBase<PlantStockTransaction>
    {
    }

    // This class has the method named GetKnownTypes that returns a generic IEnumerable.
    static class PlantStockTransactionDSHelper
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            return Helper.GetKnownTypes<PlantStockTransaction>(provider);
        }
    }
}