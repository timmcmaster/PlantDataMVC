using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PlantDataMvc3.Core.ServiceLayer
{
    [DataContract]
    public class UpdateRequest<T>: Request
    {
        [DataMember]
        public T Item { get; set; }

        public UpdateRequest(T item): base()
        {
            Item = item;
        }
    }
}