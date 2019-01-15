using Framework.Web.Forms;
using PlantDataMVC.DTO.Entities;

namespace PlantDataMVC.UI.Models.EditModels
{
    public class PlantStockEntryCreateEditModel : IForm
    {
        public int SpeciesId { get; set; }
        public ProductTypeDTO ProductType { get; set; }
        public int QuantityInStock { get; set; }
    }
}
