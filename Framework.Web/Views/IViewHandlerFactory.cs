﻿namespace Framework.Web.Views
{
    public interface IViewHandlerFactory
    {
        IViewHandler<TQuery, TViewModel> Create<TQuery, TViewModel>() where TQuery : IViewQuery<TViewModel>;
    }
}