using Framework.Web.Views;

namespace PlantDataMVC.UI.Controllers.Queries
{
    public class ShowQuery: IViewQuery
    {

        public ShowQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}