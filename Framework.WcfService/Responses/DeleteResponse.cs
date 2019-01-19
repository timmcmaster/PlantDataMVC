using System.Runtime.Serialization;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;

namespace Framework.WcfService.Responses
{
    [DataContract(Name = "DeleteResponseUsing{0}")]
    public class DeleteResponse<T> : Response, IDeleteResponse<T>
    {
        public DeleteResponse(ServiceActionStatus status) : base()
        {
            Status = status;
        }
    }
}