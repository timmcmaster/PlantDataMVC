using System.Collections.Generic;

namespace Interfaces.WcfService.Responses
{
    public interface IListResponse<T> : IResponse
    {
        IList<T> Items { get; set; }
    }
}