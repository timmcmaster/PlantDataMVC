using System.Threading.Tasks;

namespace Framework.Web.Forms
{
    public interface IFormHandler<TForm> where TForm : IForm
    {
        Task<bool> HandleAsync(TForm form);
    }
}