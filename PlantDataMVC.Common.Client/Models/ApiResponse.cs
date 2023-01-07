using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace PlantDataMVC.Common.Client.Models
{
    public class ApiResponse
    {
        public HttpStatusCode? StatusCode { get; set; }
        public ApiPagingInfo? PagingInfo { get; set; }
        public LinkHeader? LinkInfo { get; set; }
        public bool Success { get; set; }
    }

    public class ApiResponse<TResponse> : ApiResponse
    {
        [MaybeNull]
        [AllowNull]
        public TResponse Content { get; set; }
    }
}
