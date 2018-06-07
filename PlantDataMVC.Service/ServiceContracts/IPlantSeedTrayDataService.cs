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
        [OperationContract]
        new ICreateResponse<PlantSeedTray> Create(ICreateRequest<PlantSeedTray> request);

        [OperationContract]
        new IViewResponse<PlantSeedTray> View(IViewRequest<PlantSeedTray> request);

        [OperationContract]
        new IUpdateResponse<PlantSeedTray> Update(IUpdateRequest<PlantSeedTray> request);

        [OperationContract]
        new IDeleteResponse<PlantSeedTray> Delete(IDeleteRequest<PlantSeedTray> request);

        [OperationContract]
        new IListResponse<PlantSeedTray> List(IListRequest<PlantSeedTray> request);
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