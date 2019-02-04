namespace Framework.Web.Forms
{
    public interface IFormHandlerFactory
    {
        IFormHandler<TForm, TResult> Create<TForm,TResult>() where TForm : IForm<TResult>;
    }
}