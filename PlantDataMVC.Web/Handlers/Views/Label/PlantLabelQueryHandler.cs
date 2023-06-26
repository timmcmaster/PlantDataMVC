using Framework.Web.Views;
using PlantDataMVC.Web.Controllers.Queries.Label;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.Label;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Views.Label
{
    public class PlantLabelQueryHandler : IQueryHandler<PlantLabelQuery, ListViewModelStatic<PlantLabelListViewModel>>
    {
        public PlantLabelQueryHandler()
        {
        }

        public Task<ListViewModelStatic<PlantLabelListViewModel>> Handle(PlantLabelQuery query, CancellationToken cancellationToken)
        {
            var modelList = new List<PlantLabelListViewModel>();

            var model = new ListViewModelStatic<PlantLabelListViewModel>(modelList,1,0,0, query.SortBy, query.SortAscending);

            return Task.FromResult(model);
        }
    }
}