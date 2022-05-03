namespace Framework.Web.Core.Views
{
    public interface IQueryHandlerFactory
    {
        IQueryHandler<TQuery, TViewModel> Create<TQuery, TViewModel>() where TQuery : IQuery<TViewModel>;
    }
}