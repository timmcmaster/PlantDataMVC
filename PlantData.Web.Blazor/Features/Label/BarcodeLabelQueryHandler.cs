using Framework.Web.Views;
using PlantData.Web.Blazor.UIModels.ViewModels.Label;
using System.Threading;
using System.Threading.Tasks;

namespace PlantData.Web.Blazor.Features.Labels;

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