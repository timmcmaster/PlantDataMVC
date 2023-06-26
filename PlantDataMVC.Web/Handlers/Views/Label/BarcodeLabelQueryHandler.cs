using Framework.Web.Views;
using PlantDataMVC.Web.Controllers.Queries.Label;
using PlantDataMVC.Web.Models.ViewModels;
using PlantDataMVC.Web.Models.ViewModels.Label;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Views.Label
{
    public class BarcodeLabelQueryHandler : IQueryHandler<BarcodeLabelQuery, ListViewModelStatic<BarcodeLabelListViewModel>>
    {
        public BarcodeLabelQueryHandler()
        {   
        }

        public Task<ListViewModelStatic<BarcodeLabelListViewModel>> Handle(BarcodeLabelQuery query, CancellationToken cancellationToken)
        {
            var modelList = new List<BarcodeLabelListViewModel>();

            var model = new ListViewModelStatic<BarcodeLabelListViewModel>(modelList,1,0,0, query.SortBy, query.SortAscending);

            return Task.FromResult(model);
        }
    }
}