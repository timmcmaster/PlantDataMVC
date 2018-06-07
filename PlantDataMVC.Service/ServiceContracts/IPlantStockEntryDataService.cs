using Framework.Service.Entities;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;

namespace PlantDataMVC.Service.ServiceContracts
{
    [ServiceKnownType("GetKnownTypes", typeof(PlantStockEntryDSHelper))]
    [ServiceContract]
    public interface IPlantStockEntryDataService : IDataServiceBase<PlantStockEntry>
    {
        [OperationContract]
        new ICreateResponse<PlantStockEntry> Create(ICreateRequest<PlantStockEntry> request);

        [OperationContract]
        new IViewResponse<PlantStockEntry> View(IViewRequest<PlantStockEntry> request);

        [OperationContract]
        new IUpdateResponse<PlantStockEntry> Update(IUpdateRequest<PlantStockEntry> request);

        [OperationContract]
        new IDeleteResponse<PlantStockEntry> Delete(IDeleteRequest<PlantStockEntry> request);

        [OperationContract]
        new IListResponse<PlantStockEntry> List(IListRequest<PlantStockEntry> request);
    }

    // This class has the method named GetKnownTypes that returns a generic IEnumerable.
    static class PlantStockEntryDSHelper
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            return Helper.GetKnownTypes<PlantStockEntry>(provider);
        }
    }
}