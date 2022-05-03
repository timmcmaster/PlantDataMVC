using System.Collections.Generic;

namespace Framework.Web.Core.Views
{
    /// <summary>
    /// Marker interface for all types implementing IQuery
    /// </summary>
    public interface IQueryBase
    {
    }

    // TViewModel is contravariant so IQuery<ViewModel> can be assigned to var of type IQuery<DerivedViewModel> 
    // Why is it needed?
    public interface IQuery<out TViewModel> : IQueryBase
    {
    }

    public interface IQueryForList<TListItem, out TViewModel> : IQuery<TViewModel> where TViewModel :IEnumerable<TListItem>
    {
    }
}
