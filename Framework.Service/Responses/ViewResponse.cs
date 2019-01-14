using Interfaces.Service;
using Interfaces.Service.Responses;
using System.Runtime.Serialization;

namespace Framework.Service.Responses
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