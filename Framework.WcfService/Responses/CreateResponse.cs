﻿using System.Runtime.Serialization;
using Interfaces.WcfService;
using Interfaces.WcfService.Responses;

namespace Framework.WcfService.Responses
{
    [DataContract(Name = "CreateResponseUsing{0}")]
    public class CreateResponse<T> : Response, ICreateResponse<T>
    {
        public CreateResponse(T item, ServiceActionStatus status)
        {
            Item = item;
            Status = status;
        }

        #region ICreateResponse<T> Members
        [DataMember] public int Id { get; set; }

        [DataMember] public T Item { get; set; }
        #endregion
    }
}