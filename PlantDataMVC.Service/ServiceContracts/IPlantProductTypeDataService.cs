using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using System.ServiceModel;

namespace PlantDataMVC.Service.ServiceContracts
{
    [ServiceContract]
    public interface IPlantProductTypeDataService : IDataServiceBase<PlantProductType>
    {
        [OperationContract]
        new ICreateResponse<PlantProductType> Create(ICreateRequest<PlantProductType> request);

        [OperationContract]
        new IViewResponse<PlantProductType> View(IViewRequest<PlantProductType> request);

        [OperationContract]
        new IUpdateResponse<PlantProductType> Update(IUpdateRequest<PlantProductType> request);

        [OperationContract]
        new IDeleteResponse<PlantProductType> Delete(IDeleteRequest<PlantProductType> request);

        [OperationContract]
        new IListResponse<PlantProductType> List(IListRequest<PlantProductType> request);
    }
}
