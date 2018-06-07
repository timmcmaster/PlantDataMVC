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
        [OperationContract]
        new ICreateResponse<Plant> Create(ICreateRequest<Plant> request);

        [OperationContract]
        new IViewResponse<Plant> View(IViewRequest<Plant> request);

        [OperationContract]
        new IUpdateResponse<Plant> Update(IUpdateRequest<Plant> request);

        [OperationContract]
        new IDeleteResponse<Plant> Delete(IDeleteRequest<Plant> request);

        [OperationContract]
        new IListResponse<Plant> List(IListRequest<Plant> request);
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
