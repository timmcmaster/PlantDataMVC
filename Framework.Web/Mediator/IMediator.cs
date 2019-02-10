using System.Threading;
using System.Threading.Tasks;
using Framework.Web.Forms;
using Framework.Web.Views;

namespace Framework.Web.Mediator
{
    public interface IMediator
    {
        /// <summary>
        /// Asynchronously makes a request using the specified query.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model (response).</typeparam>
        /// <param name="query">The query request.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        /// <returns>A task that represents the request operation</returns>
        Task<TViewModel> Request<TViewModel>(IQuery<TViewModel> query, CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously sends the specified form.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="form">The form.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        /// <returns>A task that represents the send operation</returns>
        Task<TResult> Send<TResult>(IForm<TResult> form, CancellationToken cancellationToken = default);
    }
}
