using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using System.ServiceModel;

namespace PlantDataMVC.Service.ServiceContracts
{
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
}
