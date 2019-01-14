using Interfaces.DTO;
using Interfaces.Service.Responses;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Interfaces.WCFService
{
    [ServiceContract]
    public interface IWcfService<T> where T : IDtoEntity
    {
        // POST: api/Plant
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item")]
        ICreateResponse<T> Create(T item);

        // GET: api/Plant/5
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item?id={id}")]
        IViewResponse<T> View(int id);

        // PUT: api/Plant/5
        [OperationContract]
        [WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item?id={id}")]
        IUpdateResponse<T> Update(int id, T item);

        // DELETE: api/Plant/5
        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item?id={id}")]
        IDeleteResponse<T> Delete(int id);

        // GET: api/Plant
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item")]
        IListResponse<T> List();
    }
}