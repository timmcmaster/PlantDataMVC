using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Framework.Service.ServiceLayer
{
    [DataContract]
    public class DeleteRequest<T> : Request
    {
        [DataMember]
        public int Id { get; set; }

        public DeleteRequest(int id)
            : base()
        {
            Id = id;
        }
    }
}