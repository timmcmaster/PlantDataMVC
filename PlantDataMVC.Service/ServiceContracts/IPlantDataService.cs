using Framework.Service.Entities;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;

namespace PlantDataMVC.Service.ServiceContracts
{
    [ServiceKnownType("GetKnownTypes", typeof(PlantDSHelper))]
    [ServiceContract]
    public interface IPlantDataService: IDataServiceBase<Plant>
    {
    }

    // This class has the method named GetKnownTypes that returns a generic IEnumerable.
    static class PlantDSHelper
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            return Helper.GetKnownTypes<Plant>(provider);
        }
    }
}
