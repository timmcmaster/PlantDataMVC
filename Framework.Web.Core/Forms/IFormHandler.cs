using System.Threading;
using System.Threading.Tasks;

namespace Framework.Web.Core.Forms
{
    /// <summary>
    /// The form is bound to the result type it returns, so that forms aren't used against the wrong result type
    /// TQuery is covariant so IFormHandler<Form<Result>,Result> can be assigned to var of type IFormHandler<FormBase<Result>,Result> 
    /// Why do we need covariance?    
    /// </summary>
    /// <typeparam name="TForm">The type of the form.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IFormHandler<in TForm, TResult> where TForm : IForm<TResult>
    {
        Task<TResult> HandleAsync(TForm form, CancellationToken cancellationToken);
    }
}