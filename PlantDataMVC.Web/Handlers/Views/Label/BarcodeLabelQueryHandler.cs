using Framework.Web.Views;
using PlantDataMVC.Web.Controllers.Queries.Label;
using PlantDataMVC.Web.Models.ViewModels.Label;
using System.Threading;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.Handlers.Views.Label
{
    public class BarcodeLabelQueryHandler : IQueryHandler<BarcodeLabelQuery, BarcodeLabelsViewModel>
    {
        public BarcodeLabelQueryHandler()
        {   
        }

        public Task<BarcodeLabelsViewModel> Handle(BarcodeLabelQuery query, CancellationToken cancellationToken)
        {
            var model = new BarcodeLabelsViewModel(); 

            return Task.FromResult(model);
        }
    }
}