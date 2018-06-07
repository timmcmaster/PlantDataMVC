using Framework.Service.Entities;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;

namespace PlantDataMVC.Service.ServiceContracts
{
    [ServiceKnownType("GetKnownTypes", typeof(PlantStockTransactionTypeDSHelper))]
    [ServiceContract]
    public interface IPlantStockTransactionTypeDataService : IDataServiceBase<PlantStockTransactionType>
    {
        [OperationContract]
        new ICreateResponse<PlantStockTransactionType> Create(ICreateRequest<PlantStockTransactionType> request);

        [OperationContract]
        new IViewResponse<PlantStockTransactionType> View(IViewRequest<PlantStockTransactionType> request);

        [OperationContract]
        new IUpdateResponse<PlantStockTransactionType> Update(IUpdateRequest<PlantStockTransactionType> request);

        [OperationContract]
        new IDeleteResponse<PlantStockTransactionType> Delete(IDeleteRequest<PlantStockTransactionType> request);

        [OperationContract]
        new IListResponse<PlantStockTransactionType> List(IListRequest<PlantStockTransactionType> request);
    }

    // This class has the method named GetKnownTypes that returns a generic IEnumerable.
    static class PlantStockTransactionTypeDSHelper
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            return Helper.GetKnownTypes<PlantStockTransactionType>(provider);
        }
    }
}