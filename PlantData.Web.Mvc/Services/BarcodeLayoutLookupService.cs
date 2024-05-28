using Framework.Web.Services;
using MediatR;
using PlantDataMVC.Api.Models.DataModels;

namespace PlantData.Web.Mvc.Services
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
