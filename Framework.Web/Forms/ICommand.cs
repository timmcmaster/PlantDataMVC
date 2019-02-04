namespace Framework.Web.Forms
{
    /// <summary>
    ///     Marker interface for forms
    /// </summary>
    public interface ICommand<TForm> where TForm : IForm
    {
    }
}