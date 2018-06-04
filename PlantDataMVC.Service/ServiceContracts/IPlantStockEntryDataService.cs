using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using System.ServiceModel;

namespace PlantDataMVC.Service.ServiceContracts
{
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

}
