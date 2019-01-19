using System.Runtime.Serialization;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;

namespace Framework.WcfService.Responses
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