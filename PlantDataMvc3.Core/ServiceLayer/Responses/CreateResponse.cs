using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace PlantDataMvc3.Core.ServiceLayer
{
    [DataContract]
    public class CreateResponse<T>: Response
    {
        [DataMember]
        public int Id { get; set; }
        
        [DataMember]
        public T Item { get; set; }

        public CreateResponse(int id, T item):base()
        {
            Id = id;
            Item = item;
        }
    }
}