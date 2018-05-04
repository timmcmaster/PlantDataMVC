using Interfaces.Service;
using System.Runtime.Serialization;

namespace Framework.Service.ServiceLayer
{
    [DataContract]
    public class UpdateResponse<T> : Response, IUpdateResponse<T>
    {
        [DataMember]
        public T Item { get; set; }

        public UpdateResponse(T item): base()
        {
            Item = item;
        }
    }
}