using PlantDataMVC.Domain.Entities;
using PlantDataMVC.UI.Forms;
using PlantDataMVC.UI.ModelBinders;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Models
{
    // HACK: So that we can debug binding for this model
    [ModelBinder(typeof(DebugModelBinder))]
    public class PlantStockEntryUpdateEditModel : IForm
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        //public int ProductTypeId { get; set; }
        public PlantProductType ProductType { get; set; }
        public int QuantityInStock { get; set; }
    }
}
