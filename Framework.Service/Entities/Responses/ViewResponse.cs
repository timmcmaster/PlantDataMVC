using Interfaces.Service;
using System.Runtime.Serialization;

namespace Framework.Service.Entities
{
    [DataContract]
    public class ViewResponse<T> : Response, IViewResponse<T>
    {
        [DataMember]
        public T Item { get; set; }

        public ViewResponse(T item) : base()
        {
            Item = item;
        }
    }
}