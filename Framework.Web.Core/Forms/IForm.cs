namespace Framework.Web.Core.Forms
{
    /// <summary>
    ///     Marker interface for forms
    /// </summary>
    public interface IFormBase
    {
    }

    // TResult is contravariant so IForm<Result> can be assigned to var of type IForm<DerivedResult>
    // Why is it needed?
    public interface IForm<out TResult>: IFormBase
    {
    }
}