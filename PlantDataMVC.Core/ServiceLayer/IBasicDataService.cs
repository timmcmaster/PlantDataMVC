using System.ServiceModel;
using PlantDataMVC.Core.Domain.BusinessObjects;

namespace PlantDataMVC.Core.ServiceLayer
{
    [ServiceContract]
    public interface IBasicDataService<T> where T : DomainEntity
    {
        [OperationContract]
        CreateResponse<T> Create(CreateRequest<T> request);

        [OperationContract]
        ViewResponse<T> View(ViewRequest<T> request);
        
        [OperationContract]
        UpdateResponse<T> Update(UpdateRequest<T> request);

        [OperationContract]
        DeleteResponse<T> Delete(DeleteRequest<T> request);

        [OperationContract]
        ListResponse<T> List(ListRequest<T> request);
    }
}