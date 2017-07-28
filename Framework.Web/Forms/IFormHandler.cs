namespace Framework.Web.Forms
{
    public interface IFormHandler<TForm> where TForm : IForm
    {
        void Handle(TForm form);
    }
}
