using System.Collections.Generic;

namespace Interfaces.Service.Responses
{
    public interface IListResponse
    {
    }

    public interface IListResponse<T> : IResponse, IListResponse
    {
        IList<T> Items { get; set; }
    }
}