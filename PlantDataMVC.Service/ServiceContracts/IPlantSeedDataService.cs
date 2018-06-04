using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using System.ServiceModel;

namespace PlantDataMVC.Service.ServiceContracts
{
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
}
