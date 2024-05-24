using Framework.Web.Services;
using MediatR;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Blazor.Services
{
    public interface IBarcodeLayoutLookupService : ILookupService<BarcodeLabelLayoutDataModel>
    {
    }

    public class BarcodeLayoutLookupService : LookupService<BarcodeLabelLayoutDataModel>, IBarcodeLayoutLookupService
    {
        public BarcodeLayoutLookupService(IMediator mediator) : base(mediator)
        {
        }
    }
}