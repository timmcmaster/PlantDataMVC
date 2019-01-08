using Interfaces.Service;
using System.Runtime.Serialization;

namespace Framework.Service.Entities
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

        public CreateResponse(int id, T item, ServiceActionStatus status, int errorCode) : this(id, item, status)
        {
            ErrorCode = errorCode;
        }
    }
}