using Framework.Web.Services;
using MediatR;
using PlantData.Web.Blazor.Features.Common.List;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Blazor.Features.Labels
{
    public interface IBarcodeLayoutLookupService : ILookupServiceAsync<BarcodeLabelLayoutDataModel>
    {
    }

    public class BarcodeLayoutLookupService : LookupServiceAsync<BarcodeLabelLayoutDataModel>, IBarcodeLayoutLookupService
    {
        public BarcodeLayoutLookupService(IMediator mediator) : base(mediator)
        {
        }
    }
}