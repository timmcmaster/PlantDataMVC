using Interfaces.WcfService.Responses;
using PlantDataMVC.DTO.Dtos;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace PlantDataMVC.WCFService.ServiceContracts
{
    [ServiceKnownType("GetKnownTypes", typeof(ProductTypeDtoDsHelper))]
    [ServiceContract]
    public interface IProductTypeWcfService
    {
        // POST: api/Plant
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item")]
        ICreateResponse<ProductTypeDto> Create(ProductTypeDto item);

        // GET: api/Plant/5
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item?id={id}")]
        IViewResponse<ProductTypeDto> View(int id);

        // PUT: api/Plant/5
        [OperationContract]
        [WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item?id={id}")]
        IUpdateResponse<ProductTypeDto> Update(int id, ProductTypeDto item);

        // DELETE: api/Plant/5
        [OperationContract]
        [WebInvoke(Method = "DELETE", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item?id={id}")]
        IDeleteResponse<ProductTypeDto> Delete(int id);

        // GET: api/Plant
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Item")]
        IListResponse<ProductTypeDto> List();
    }

    // This class has the method named GetKnownTypes that returns a generic IEnumerable.
    internal static class ProductTypeDtoDsHelper
    {
        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            return DtoHelper.GetKnownTypes<ProductTypeDto>(provider);
        }
    }
}