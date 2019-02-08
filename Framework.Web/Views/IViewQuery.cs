using System.Collections.Generic;

namespace Framework.Web.Views
{
    /// <summary>
    /// Marker interface for all types implementing IViewQuery
    /// </summary>
    public interface IViewQueryBase
    {
    }

    // TViewModel is contravariant so IViewQuery<ViewModel> can be assigned to var of type IViewQuery<DerivedViewModel> 
    // Why is it needed?
    public interface IViewQuery<out TViewModel> : IViewQueryBase
    {
    }

    public interface IViewQueryForList<TListItem, out TViewModel> : IViewQuery<TViewModel> where TViewModel :IEnumerable<TListItem>
    {
    }
}
