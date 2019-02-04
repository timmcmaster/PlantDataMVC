﻿using System.Threading.Tasks;
using Framework.Web.Forms;
using Framework.Web.Views;

namespace Framework.Web.Mediator
{
    public interface IMediator
    {
        Task<TViewModel> Request<TViewModel>(IViewQuery<TViewModel> query);
        Task<TResult> Send<TResult>(IForm<TResult> form);
    }
}
