using Interfaces.Domain;
using System.ServiceModel;

namespace Interfaces.Service
{
    // TODO: Sort out whether I can put WCF-specific attriubutes (contract stuff) elsewhere 
    // where we need WCF stuff (and not before)
    [ServiceContract]
    public interface IBasicDataService<T> where T : IDomainEntity
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