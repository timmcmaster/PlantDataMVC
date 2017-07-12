namespace PlantDataMVC.UI.Forms
{
    public interface IFormHandler<TForm> where TForm : IForm
    {
        void Handle(TForm form);
    }
}
