using Framework.Web.Views;

namespace PlantDataMVC.UI.Controllers.Queries
{
    public class IndexQuery: IViewQuery
    {

        public IndexQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }

    }
}