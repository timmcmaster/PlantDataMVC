using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using System.ServiceModel;

namespace PlantDataMVC.Service.ServiceContracts
{
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
}
