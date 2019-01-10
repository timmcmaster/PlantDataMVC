using Framework.Service.Entities;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;

namespace PlantDataMVC.Service.ServiceContracts
{
    [ServiceKnownType("GetKnownTypes", typeof(PlantProductTypeDSHelper))]
    [ServiceContract]
    public interface IPlantProductTypeDataService : IDataServiceBase<PlantProductType>
    {
    }

    // This class has the method named GetKnownTypes that returns a generic IEnumerable.
    static class PlantProductTypeDSHelper
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            return Helper.GetKnownTypes<PlantProductType>(provider);
        }
    }
}
