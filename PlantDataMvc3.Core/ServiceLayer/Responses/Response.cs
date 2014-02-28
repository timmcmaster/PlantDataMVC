using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PlantDataMvc3.Core.ServiceLayer
{
    [DataContract]
    public abstract class Response
    {
        [DataMember]
        public int ErrorCode { get; set; }

        public Response()
        {
        }
    }
}