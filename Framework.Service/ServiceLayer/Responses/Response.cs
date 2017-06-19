using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Framework.Service.ServiceLayer
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