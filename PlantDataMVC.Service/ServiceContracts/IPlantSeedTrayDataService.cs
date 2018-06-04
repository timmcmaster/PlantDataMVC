using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using System.ServiceModel;

namespace PlantDataMVC.Service.ServiceContracts
{
    [ServiceContract]
    public interface IPlantSeedTrayDataService : IDataServiceBase<PlantSeedTray>
    {
        [OperationContract]
        new ICreateResponse<PlantSeedTray> Create(ICreateRequest<PlantSeedTray> request);

        [OperationContract]
        new IViewResponse<PlantSeedTray> View(IViewRequest<PlantSeedTray> request);

        [OperationContract]
        new IUpdateResponse<PlantSeedTray> Update(IUpdateRequest<PlantSeedTray> request);

        [OperationContract]
        new IDeleteResponse<PlantSeedTray> Delete(IDeleteRequest<PlantSeedTray> request);

        [OperationContract]
        new IListResponse<PlantSeedTray> List(IListRequest<PlantSeedTray> request);
    }
}
