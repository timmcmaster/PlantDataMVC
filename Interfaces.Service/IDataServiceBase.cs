using Interfaces.Domain;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Interfaces.Service
{
    [ServiceContract]
    public interface IDataServiceBase<T> where T : IDomainEntity
    {
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "")]
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