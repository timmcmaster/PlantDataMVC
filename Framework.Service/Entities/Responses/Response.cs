﻿using Interfaces.Service;
using System.Runtime.Serialization;

namespace Framework.Service.Entities
{
    [DataContract]
    public abstract class Response : IResponse
    {
        [DataMember]
        public int ErrorCode { get; set; }

        public Response()
        {
        }
    }
}