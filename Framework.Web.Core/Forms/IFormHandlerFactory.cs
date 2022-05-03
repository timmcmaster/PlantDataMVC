namespace Framework.Web.Core.Forms
{
    public interface IFormHandlerFactory
    {
        IFormHandler<TForm, TResult> Create<TForm,TResult>() where TForm : IForm<TResult>;
    }
}