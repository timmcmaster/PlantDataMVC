using Interfaces.Service;
using System.Runtime.Serialization;

namespace Framework.Service.Entities
{
    [DataContract(Name = "CreateRequestUsing{0}")]
    public class CreateRequest<T> : ICreateRequest<T>
    {
        [DataMember]
        public T Item { get; set; }

        public CreateRequest(T item) : base()
        {
            Item = item;
        }
    }
}