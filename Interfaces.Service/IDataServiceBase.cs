using Interfaces.Domain;
using System.ServiceModel;

namespace Interfaces.Service
{
    [ServiceContract]
    public interface IDataServiceBase<T> where T : IDomainEntity
    {
        [OperationContract]
        ICreateResponse<T> Create(ICreateRequest<T> request);

        [OperationContract]
        IViewResponse<T> View(IViewRequest<T> request);

        [OperationContract]
        IUpdateResponse<T> Update(IUpdateRequest<T> request);

        [OperationContract]
        IDeleteResponse<T> Delete(IDeleteRequest<T> request);

        [OperationContract]
        IListResponse<T> List(IListRequest<T> request);
    }
}