using PlantDataMVC.UI.Forms;

namespace PlantDataMVC.UI.Models
{
    public class PlantStockEntryCreateEditModel : IForm
    {
        public int SpeciesId { get; set; }
        public int ProductTypeId { get; set; }
        public int QuantityInStock { get; set; }
    }
}
