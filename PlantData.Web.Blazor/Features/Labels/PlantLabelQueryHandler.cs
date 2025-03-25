using Framework.Web.Views;
using PlantData.Web.Blazor.SharedComponents.Grid;
using PlantData.Web.Blazor.UIModels.ViewModels.Label;
using PlantData.Web.Mvc.Controllers.Queries.Label;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.Labels
{
    public class PlantLabelQueryHandler : IQueryHandler<PlantLabelQuery, GridDataModel<PlantLabelGridModel>>
    {
        public PlantLabelQueryHandler()
        {
        }

        public Task<GridDataModel<PlantLabelGridModel>> Handle(PlantLabelQuery query, CancellationToken cancellationToken)
        {
            var modelList = new List<PlantLabelGridModel>();

            var model = new GridDataModel<PlantLabelGridModel>(modelList, 1, 0, 0, query.SortBy, query.SortAscending);

            return Task.FromResult(model);
        }
    }
}