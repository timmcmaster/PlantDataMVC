using Interfaces.Service;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Framework.Service.Entities
{
    [DataContract]
    public class ListResponse<T> : Response, IListResponse<T>
    {
        [DataMember]
        public IList<T> Items { get; set; }

        public ListResponse(IList<T> items) : base()
        {
            Items = new List<T>();
            ((List<T>)Items).AddRange(items);
        }
    }
}