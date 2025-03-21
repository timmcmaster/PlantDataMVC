using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framework.Web.Services
{
    public interface ILookupService<TItem> where TItem : class
    {
        IEnumerable<TItem> GetData();
        IEnumerable<TItem> GetOrderedData(Func<TItem, string> displayValueSelector);
    }

    public interface ILookupServiceAsync<TItem> where TItem : class
    {
        Task<IEnumerable<TItem>> GetData();
        Task<IEnumerable<TItem>> GetOrderedData(Func<TItem, string> displayValueSelector);
    }
}
