using PlantDataMVC.Domain.Entities;
using PlantDataMVC.UI.Forms;

namespace PlantDataMVC.UI.Models
{
    public class PlantStockEntryUpdateEditModel : IForm
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public PlantProductType ProductType { get; set; }
        public int QuantityInStock { get; set; }
    }
}
