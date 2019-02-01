using System.Runtime.Serialization;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;

namespace Framework.WcfService.Responses
{
    [DataContract(Name = "UpdateResponseUsing{0}")]
    public class UpdateResponse<T> : Response, IUpdateResponse<T>
    {
        public UpdateResponse(T item, ServiceActionStatus status)
        {
            Item = item;
            Status = status;
        }

        #region IUpdateResponse<T> Members
        [DataMember] public T Item { get; set; }
        #endregion
    }
}