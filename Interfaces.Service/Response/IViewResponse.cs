namespace Interfaces.Service
{
    public interface IViewResponse<T>: IResponse
    {
        T Item { get; set; }
    }
}