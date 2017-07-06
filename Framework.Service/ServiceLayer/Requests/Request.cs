using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Framework.Service.ServiceLayer
{
    /// <summary>
    /// A request is the basic unit for communication with a data service.
    /// A data service action takes a Request object and returns a Response object. 
    /// </summary>
    [DataContract]
    public abstract class Request
    {
        public Request()
        {
        }
    }
}