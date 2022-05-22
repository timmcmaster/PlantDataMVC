namespace Framework.Web.Core.Forms
{
    // TResult is contravariant so IForm<Result> can be assigned to var of type IForm<DerivedResult>
    // Why is it needed?
    public interface IForm<out TResult>: MediatR.IRequest<TResult>
    {
    }
}