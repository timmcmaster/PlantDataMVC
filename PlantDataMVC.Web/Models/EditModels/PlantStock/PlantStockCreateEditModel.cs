using Framework.Web.Forms;

namespace PlantDataMVC.UICore.Models.EditModels.PlantStock
{
    public class PlantStockCreateEditModel : IForm<bool>
    {
        public int SpeciesId { get; set; }
        //public ProductTypeDto ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public int QuantityInStock { get; set; }
    }
}
