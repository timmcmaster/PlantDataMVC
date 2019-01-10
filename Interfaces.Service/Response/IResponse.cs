using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Interfaces.Service
{
    public interface IResponse
    {
        ServiceActionStatus Status { get; }
    }
}