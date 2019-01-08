using Interfaces.Service;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Framework.Service.Entities
{
    [DataContract(Name = "ListResponseUsing{0}")]
    public class ListResponse<T> : Response, IListResponse<T>
    {
        [DataMember]
        public IList<T> Items { get; set; }

        public ListResponse(IList<T> items, ServiceActionStatus status) : base()
        {
            Items = new List<T>();
            ((List<T>)Items).AddRange(items);
            Status = status;
        }

        public ListResponse(IList<T> items, ServiceActionStatus status, int errorCode) : this(items, status)
        {
            ErrorCode = errorCode;
        }
    }
}