using System.Collections.Generic;
using System.Runtime.Serialization;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;

namespace Framework.WcfService.Responses
{
    [DataContract(Name = "ListResponseUsing{0}")]
    public class ListResponse<T> : Response, IListResponse<T>
    {
        [DataMember]
        public IList<T> Items { get; set; }

        public ListResponse(IList<T> items, ServiceActionStatus status)
        {
            Items = new List<T>();
            ((List<T>)Items).AddRange(items);
            Status = status;
        }
    }
}