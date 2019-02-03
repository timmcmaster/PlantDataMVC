using System.Threading.Tasks;

namespace Framework.Web.Views
{
    //public interface IViewHandler<TQuery, TViewModel> where TViewModel : IViewModel
    //                                                     where TQuery : IViewQuery
    //{
    //    Task<TViewModel> HandleAsync(TQuery query);
    //}

    // Use the below once we need specific queries per model type
    // The query is bound to the model type it acts on, so that queries aren't used against the wrong model 
    public interface IViewHandler<TQuery, TViewModel> where TViewModel : IViewModel
                                                      where TQuery : IViewQuery<TViewModel>
    {
        Task<TViewModel> HandleAsync(TQuery query);
    }
}