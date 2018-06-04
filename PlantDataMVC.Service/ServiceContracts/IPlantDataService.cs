using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using System.ServiceModel;

namespace PlantDataMVC.Service.ServiceContracts
{
    [ServiceContract]
    public interface IPlantDataService: IDataServiceBase<Plant>
    {
        [OperationContract]
        new ICreateResponse<Plant> Create(ICreateRequest<Plant> request);

        [OperationContract]
        new IViewResponse<Plant> View(IViewRequest<Plant> request);

        [OperationContract]
        new IUpdateResponse<Plant> Update(IUpdateRequest<Plant> request);

        [OperationContract]
        new IDeleteResponse<Plant> Delete(IDeleteRequest<Plant> request);

        [OperationContract]
        new IListResponse<Plant> List(IListRequest<Plant> request);
    }

}
