using Interfaces.Service;
using System.Runtime.Serialization;

namespace Framework.Service.Entities
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