using Interfaces.Service;
using Interfaces.Service.Responses;
using System.Runtime.Serialization;

namespace Framework.Service.Responses
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