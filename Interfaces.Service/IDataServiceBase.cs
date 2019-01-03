using Interfaces.Domain;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Interfaces.Service
{
    [ServiceContract]
    public interface IDataServiceBase<T> where T : IDomainEntity
    {
        // POST: api/Plant
        [OperationContract]
        ICreateResponse<T> Create(ICreateRequest<T> request);

        // GET: api/Plant/5
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "api/Plant/{id}")]
        IViewResponse<T> View(IViewRequest<T> request);

        // PUT: api/Plant/5
        [OperationContract]
        IUpdateResponse<T> Update(IUpdateRequest<T> request);

        // DELETE: api/Plant/5
        [OperationContract]
        IDeleteResponse<T> Delete(IDeleteRequest<T> request);

        // GET: api/Plant
        [OperationContract]
        IListResponse<T> List(IListRequest<T> request);
    }
}