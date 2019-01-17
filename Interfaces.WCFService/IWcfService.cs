using Interfaces.DTO;
using Interfaces.Service.Responses;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Interfaces.WCFService
{
    [ServiceContract]
    public interface IWcfService
    {
        // POST: api/Plant
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item")]
        ICreateResponse<TDtoOut> Create<TDtoIn,TDtoOut>(TDtoIn item) where TDtoIn: IDtoEntity 
                                                                     where TDtoOut : IDtoEntity;

        // GET: api/Plant/5
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item?id={id}")]
        IViewResponse<TDtoOut> View<TDtoOut>(int id) where TDtoOut : IDtoEntity;

        // PUT: api/Plant/5
        [OperationContract]
        [WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item?id={id}")]
        IUpdateResponse<TDtoOut> Update<TDtoIn, TDtoOut>(int id, TDtoIn item) where TDtoIn: IDtoEntity 
                                                                              where TDtoOut : IDtoEntity;

        // DELETE: api/Plant/5
        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item?id={id}")]
        IDeleteResponse<TDtoOut> Delete<TDtoOut>(int id) where TDtoOut : IDtoEntity;

        // GET: api/Plant
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item")]
        IListResponse<TDtoOut> List<TDtoOut>() where TDtoOut : IDtoEntity;
    }
}