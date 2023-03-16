using System;
using System.Collections.Generic;

namespace Framework.Web.Services
{
    public interface ILookupService<TItem> where TItem : class
    {
        IEnumerable<TItem> GetData();
        IEnumerable<TItem> GetOrderedData(Func<TItem, string> displayValueSelector);
    }
}
