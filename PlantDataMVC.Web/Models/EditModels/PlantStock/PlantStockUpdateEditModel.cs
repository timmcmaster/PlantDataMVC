using Framework.Web.Forms;

namespace PlantDataMVC.Web.Models.EditModels.PlantStock
{
    public class PlantStockUpdateEditModel : IForm<bool>
    {
        public int Id { get; set; }
        public int SpeciesId { get; set; }
        //public ProductTypeDataModel ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public int QuantityInStock { get; set; }
    }
}
