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
        [OperationContract]
        new ICreateResponse<PlantSeedSite> Create(ICreateRequest<PlantSeedSite> request);

        [OperationContract]
        new IViewResponse<PlantSeedSite> View(IViewRequest<PlantSeedSite> request);

        [OperationContract]
        new IUpdateResponse<PlantSeedSite> Update(IUpdateRequest<PlantSeedSite> request);

        [OperationContract]
        new IDeleteResponse<PlantSeedSite> Delete(IDeleteRequest<PlantSeedSite> request);

        [OperationContract]
        new IListResponse<PlantSeedSite> List(IListRequest<PlantSeedSite> request);
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