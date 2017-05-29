using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PlantDataMVC.Core.ServiceLayer
{
    [DataContract]
    public class ViewRequest<T>: Request
    {
        [DataMember]
        public int Id { get; set; }

        public ViewRequest(int id): base()
        {
            Id = id;
        }
    }
}