using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PlantDataMVC.Core.ServiceLayer
{
    [DataContract]
    public class DeleteResponse<T> : Response
    {
        public DeleteResponse()
            : base()
        {
        }
    }
}