using System.Runtime.Serialization;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;

namespace Framework.WcfService.Responses
{
    [DataContract(Name = "ViewResponseUsing{0}")]
    public class ViewResponse<T> : Response, IViewResponse<T>
    {
        public ViewResponse(T item, ServiceActionStatus status)
        {
            Item = item;
            Status = status;
        }

        #region IViewResponse<T> Members
        [DataMember] public T Item { get; set; }
        #endregion
    }
}