namespace Framework.Web.Views
{
    //public interface IViewQuery
    //{
    //}

    // Use the below once we need specific queries per model type
    public interface IViewQuery<TViewModel> where TViewModel : IViewModel
    {
    }
}
