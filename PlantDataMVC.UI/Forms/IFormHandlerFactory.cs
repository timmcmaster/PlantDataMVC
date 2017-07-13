namespace PlantDataMVC.UI.Forms
{
    public interface IFormHandlerFactory
    {
        IFormHandler<TForm> Create<TForm>() where TForm : IForm;
   }
}