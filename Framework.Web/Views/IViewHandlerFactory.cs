namespace Framework.Web.Views
{
    public interface IViewHandlerFactory
    {
        IViewHandler<TView, TQuery> Create<TView, TQuery>() where TView : IViewModel
                                                            where TQuery : IViewQuery;
    }
}