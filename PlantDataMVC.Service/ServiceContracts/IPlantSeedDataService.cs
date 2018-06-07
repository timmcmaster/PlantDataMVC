using Framework.Service.Entities;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;

namespace PlantDataMVC.Service.ServiceContracts
{
    [ServiceKnownType("GetKnownTypes", typeof(PlantSeedDSHelper))]
    [ServiceContract]
    public interface IPlantSeedDataService : IDataServiceBase<PlantSeed>
    {
        [OperationContract]
        new ICreateResponse<PlantSeed> Create(ICreateRequest<PlantSeed> request);

        [OperationContract]
        new IViewResponse<PlantSeed> View(IViewRequest<PlantSeed> request);

        [OperationContract]
        new IUpdateResponse<PlantSeed> Update(IUpdateRequest<PlantSeed> request);

        [OperationContract]
        new IDeleteResponse<PlantSeed> Delete(IDeleteRequest<PlantSeed> request);

        [OperationContract]
        new IListResponse<PlantSeed> List(IListRequest<PlantSeed> request);
    }

    // This class has the method named GetKnownTypes that returns a generic IEnumerable.
    static class PlantSeedDSHelper
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            return Helper.GetKnownTypes<PlantSeed>(provider);
        }
    }
}
