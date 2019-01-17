using Interfaces.Service;
using Interfaces.Service.Responses;
using System.Runtime.Serialization;

namespace Framework.Service.Responses
{
    [DataContract(Name = "CreateResponseUsing{0}")]
    public class CreateResponse<T> : Response, ICreateResponse<T>
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public T Item { get; set; }

        public CreateResponse(T item, ServiceActionStatus status) : base()
        {
            Item = item;
            Status = status;
        }
    }
}