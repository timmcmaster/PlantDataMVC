using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace PlantDataMVC.WCFService.ServiceContracts
{
    [ServiceKnownType("GetKnownTypes", typeof(JournalEntryDtoDsHelper))]
    [ServiceContract]
    public interface IJournalEntryWcfService //: IWcfService
    {
        // POST: api/Plant
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item")]
        ICreateResponse<JournalEntryDto> Create(JournalEntryDto item);

        // GET: api/Plant/5
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item?id={id}")]
        IViewResponse<JournalEntryDto> View(int id);

        // PUT: api/Plant/5
        [OperationContract]
        [WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item?id={id}")]
        IUpdateResponse<JournalEntryDto> Update(int id, JournalEntryDto item);

        // DELETE: api/Plant/5
        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item?id={id}")]
        IDeleteResponse<JournalEntryDto> Delete(int id);

        // GET: api/Plant
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item")]
        IListResponse<JournalEntryDto> List();
    }

    // This class has the method named GetKnownTypes that returns a generic IEnumerable.
    internal static class JournalEntryDtoDsHelper
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            return DtoHelper.GetKnownTypes<JournalEntryDto>(provider);
        }
    }
}