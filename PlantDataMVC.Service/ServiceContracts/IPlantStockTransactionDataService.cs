using Framework.Service.Entities;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;

namespace PlantDataMVC.Service.ServiceContracts
{
    [ServiceKnownType("GetKnownTypes", typeof(PlantStockTransactionDSHelper))]
    [ServiceContract]
    public interface IPlantStockTransactionDataService : IDataServiceBase<PlantStockTransaction>
    {
        [OperationContract]
        new ICreateResponse<PlantStockTransaction> Create(ICreateRequest<PlantStockTransaction> request);

        [OperationContract]
        new IViewResponse<PlantStockTransaction> View(IViewRequest<PlantStockTransaction> request);

        [OperationContract]
        new IUpdateResponse<PlantStockTransaction> Update(IUpdateRequest<PlantStockTransaction> request);

        [OperationContract]
        new IDeleteResponse<PlantStockTransaction> Delete(IDeleteRequest<PlantStockTransaction> request);

        [OperationContract]
        new IListResponse<PlantStockTransaction> List(IListRequest<PlantStockTransaction> request);
    }

    // This class has the method named GetKnownTypes that returns a generic IEnumerable.
    static class PlantStockTransactionDSHelper
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            return Helper.GetKnownTypes<PlantStockTransaction>(provider);
        }
    }
}