using Framework.Web.Forms;
using PlantDataMVC.DTO.Dtos;

namespace PlantDataMVC.UI.Models.EditModels.PlantStock
{
    public class PlantStockUpdateEditModel : IForm<bool>
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public ProductTypeDto ProductType { get; set; }
        public int QuantityInStock { get; set; }
    }
}
