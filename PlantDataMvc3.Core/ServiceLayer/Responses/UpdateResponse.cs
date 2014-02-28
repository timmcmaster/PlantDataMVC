using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PlantDataMvc3.Core.ServiceLayer
{
    [DataContract]
    public class UpdateResponse<T> : Response
    {
        [DataMember]
        public T Item { get; set; }

        public UpdateResponse(T item): base()
        {
            Item = item;
        }
    }
}