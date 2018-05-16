using Interfaces.Service;
using System.Runtime.Serialization;

namespace Framework.Service.Entities
{
    [DataContract]
    public class UpdateRequest<T> : IUpdateRequest<T>
    {
        [DataMember]
        public T Item { get; set; }

        public UpdateRequest(T item) : base()
        {
            Item = item;
        }
    }
}