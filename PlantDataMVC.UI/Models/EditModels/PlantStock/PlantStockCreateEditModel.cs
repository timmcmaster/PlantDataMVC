using Framework.Web.Forms;
using PlantDataMVC.DTO.Dtos;

namespace PlantDataMVC.UI.Models.EditModels.PlantStock
{
    public class PlantStockCreateEditModel : IForm<bool>
    {
        public int SpeciesId { get; set; }
        //public ProductTypeDto ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public int QuantityInStock { get; set; }
    }
}
