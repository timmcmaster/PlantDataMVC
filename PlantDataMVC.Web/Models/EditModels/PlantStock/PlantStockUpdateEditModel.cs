using Framework.Web.Forms;

namespace PlantDataMVC.UICore.Models.EditModels.PlantStock
{
    public class PlantStockUpdateEditModel : IForm<bool>
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        //public ProductTypeDto ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public int QuantityInStock { get; set; }
    }
}
