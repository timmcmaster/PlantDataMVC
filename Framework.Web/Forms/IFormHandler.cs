using System.Threading.Tasks;

namespace Framework.Web.Forms
{
    public interface IFormHandler<in TForm, TResult> where TForm : IForm<TResult>
    {
        Task<TResult> HandleAsync(TForm form);
    }
}