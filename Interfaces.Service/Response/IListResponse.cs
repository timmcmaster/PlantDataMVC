using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Interfaces.Service
{
    public interface IListResponse<T> : IResponse
    {
        IList<T> Items { get; set; }
    }
}