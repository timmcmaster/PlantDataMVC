using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PlantDataMvc3.Core.ServiceLayer
{
    [DataContract]
    public class ListRequest<T>: Request
    {
        public ListRequest(): base()
        {
        }
    }
}