using Framework.Web.Forms;
using PlantDataMVC.DTO.Dtos;

namespace PlantDataMVC.UI.Models.EditModels
{
    public class PlantStockEntryUpdateEditModel : IForm
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public ProductTypeDto ProductType { get; set; }
        public int QuantityInStock { get; set; }
    }
}
