using Framework.Service.Entities;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;

namespace PlantDataMVC.Service.ServiceContracts
{
    [ServiceKnownType("GetKnownTypes", typeof(PlantSeedSiteDSHelper))]
    [ServiceContract]
    public interface IPlantSeedSiteDataService : IDataServiceBase<PlantSeedSite>
    {
    }

    // This class has the method named GetKnownTypes that returns a generic IEnumerable.
    static class PlantSeedSiteDSHelper
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            return Helper.GetKnownTypes<PlantSeedSite>(provider);
        }
    }
}