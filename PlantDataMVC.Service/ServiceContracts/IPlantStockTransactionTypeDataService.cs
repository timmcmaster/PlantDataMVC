using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using System.ServiceModel;

namespace PlantDataMVC.Service.ServiceContracts
{
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
}
