using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Framework.Service.ServiceLayer
{
    [DataContract]
    public class ListResponse<T> : Response
    {
        [DataMember]
        public List<T> Items { get; set; }

        public ListResponse(IList<T> items): base()
        {
            Items = new List<T>();
            Items.AddRange(items);
        }
    }
}