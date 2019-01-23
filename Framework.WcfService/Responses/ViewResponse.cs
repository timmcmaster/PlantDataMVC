using System.Runtime.Serialization;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;

namespace Framework.WcfService.Responses
{
    [DataContract(Name = "ViewResponseUsing{0}")]
    public class ViewResponse<T> : Response, IViewResponse<T>
    {
        [DataMember]
        public T Item { get; set; }

        public ViewResponse(T item, ServiceActionStatus status)
        {
            Item = item;
            Status = status;
        }
    }
}