using Interfaces.Domain;
using System.ServiceModel;

namespace Framework.Service.ServiceLayer
{
    [ServiceContract]
    public interface IBasicDataService<T> where T : IDomainEntity
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