using Framework.Web.Forms;
using PlantDataMVC.DTO.Dtos;

namespace PlantDataMVC.UI.Models.EditModels
{
    public class PlantStockCreateEditModel : IForm
    {
        public int SpeciesId { get; set; }
        public ProductTypeDto ProductType { get; set; }
        public int QuantityInStock { get; set; }
    }
}
