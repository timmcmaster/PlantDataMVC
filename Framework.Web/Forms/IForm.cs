namespace Framework.Web.Forms
{
    /// <summary>
    ///     Marker interface for forms
    /// </summary>
    public interface IFormBase
    {
    }

    public interface IForm<TResult>: IFormBase
    {
    }
}