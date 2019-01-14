using Interfaces.Service;
using Interfaces.Service.Responses;
using System.Runtime.Serialization;

namespace Framework.Service.Responses
{
    [DataContract(Name = "UpdateResponseUsing{0}")]
    public class UpdateResponse<T> : Response, IUpdateResponse<T>
    {
        [DataMember]
        public T Item { get; set; }

        public UpdateResponse(T item, ServiceActionStatus status)
        {
            Item = item;
            Status = status;
        }
    }
}