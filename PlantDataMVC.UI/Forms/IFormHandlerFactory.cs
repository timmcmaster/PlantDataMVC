namespace PlantDataMVC.UI.Forms
{
    public interface IFormHandlerFactory
    {
        IFormHandler<TForm> GetFormHandler<TForm>() where TForm : IForm;
   }
}