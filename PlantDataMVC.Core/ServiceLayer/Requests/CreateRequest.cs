using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PlantDataMVC.Core.ServiceLayer
{
    [DataContract]
    public class CreateRequest<T>: Request
    {
        [DataMember]
        public T Item { get; set; }

        public CreateRequest(T item): base()
        {
            Item = item;
        }
    }
}