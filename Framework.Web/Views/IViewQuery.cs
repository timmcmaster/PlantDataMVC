namespace Framework.Web.Views
{
    /// <summary>
    /// Marker interface for all types implementing IViewQuery
    /// </summary>
    public interface IViewQueryBase
    {
    }

    // Use the below once we need specific queries per model type
    // TViewModel is contravariant so IViewQuery<ViewModel> can be assigned to var of type IViewQuery<DerivedViewModel> 
    // Why is it needed?
    public interface IViewQuery<out TViewModel> : IViewQueryBase where TViewModel : IViewModel
    {
    }
}
