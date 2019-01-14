using System.Collections.Generic;

namespace Interfaces.Service.Responses
{
    public interface IListResponse<T> : IResponse
    {
        IList<T> Items { get; set; }
    }
}