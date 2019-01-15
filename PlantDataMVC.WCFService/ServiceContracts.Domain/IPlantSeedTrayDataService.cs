using Framework.Service.Entities;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;

namespace PlantDataMVC.Service.ServiceContracts
{
    [ServiceKnownType("GetKnownTypes", typeof(PlantSeedTrayDSHelper))]
    [ServiceContract]
    public interface IPlantSeedTrayDataService : IDataServiceBase<PlantSeedTray>
    {
    }

    // This class has the method named GetKnownTypes that returns a generic IEnumerable.
    static class PlantSeedTrayDSHelper
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            return Helper.GetKnownTypes<PlantSeedTray>(provider);
        }
    }
}