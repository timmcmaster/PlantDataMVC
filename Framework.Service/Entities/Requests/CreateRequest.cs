using Interfaces.Service;
using System.Runtime.Serialization;

namespace Framework.Service.Entities
{
    [DataContract]
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