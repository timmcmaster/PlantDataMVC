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

        public CreateResponse(int id, T item, ServiceActionStatus status) : base()
        {
            Id = id;
            Item = item;
            Status = status;
        }
    }
}