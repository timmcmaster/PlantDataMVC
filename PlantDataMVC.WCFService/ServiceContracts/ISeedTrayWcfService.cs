using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace PlantDataMVC.WCFService.ServiceContracts
{
    [ServiceKnownType("GetKnownTypes", typeof(SeedTrayDtoDsHelper))]
    [ServiceContract]
    public interface ISeedTrayWcfService
    {
        // POST: api/Plant
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item")]
        ICreateResponse<SeedTrayDto> Create(SeedTrayDto item);

        // GET: api/Plant/5
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item?id={id}")]
        IViewResponse<SeedTrayDto> View(int id);

        // PUT: api/Plant/5
        [OperationContract]
        [WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item?id={id}")]
        IUpdateResponse<SeedTrayDto> Update(int id, SeedTrayDto item);

        // DELETE: api/Plant/5
        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item?id={id}")]
        IDeleteResponse<SeedTrayDto> Delete(int id);

        // GET: api/Plant
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item")]
        IListResponse<SeedTrayDto> List();
    }

    // This class has the method named GetKnownTypes that returns a generic IEnumerable.
    internal static class SeedTrayDtoDsHelper
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            return DtoHelper.GetKnownTypes<SeedTrayDto>(provider);
        }
    }
}