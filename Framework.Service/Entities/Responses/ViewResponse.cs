using Interfaces.Service;
using System.Runtime.Serialization;

namespace Framework.Service.Entities
{
    [DataContract(Name = "ViewResponseUsing{0}")]
    public class ViewResponse<T> : Response, IViewResponse<T>
    {
        [DataMember]
        public T Item { get; set; }

        public ViewResponse(T item, ServiceActionStatus status) : base()
        {
            Item = item;
            Status = status;
        }
    }
}