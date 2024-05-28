using Framework.Web.Views;
using PlantData.Web.Mvc.Controllers.Queries.Label;
using PlantData.Web.Mvc.Models.ViewModels;
using PlantData.Web.Mvc.Models.ViewModels.Label;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Mvc.Handlers.Views.Label
{
    public class PlantLabelQueryHandler : IQueryHandler<PlantLabelQuery, ListViewModelStatic<PlantLabelListViewModel>>
    {
        public PlantLabelQueryHandler()
        {
        }

        public Task<ListViewModelStatic<PlantLabelListViewModel>> Handle(PlantLabelQuery query, CancellationToken cancellationToken)
        {
            var modelList = new List<PlantLabelListViewModel>();

            var model = new ListViewModelStatic<PlantLabelListViewModel>(modelList, 1, 0, 0, query.SortBy, query.SortAscending);

            return Task.FromResult(model);
        }
    }
}