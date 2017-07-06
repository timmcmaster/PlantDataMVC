namespace PlantDataMVC.UI.Helpers
{
    public interface IFormHandlerFactory
    {
        IFormHandler<TForm> GetFormHandler<TForm>();
   }
}