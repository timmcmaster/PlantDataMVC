using Framework.Web.Forms;

namespace PlantData.Web.Mvc.Models.EditModels.PlantStock
{
    public class PlantStockCreateEditModel : IForm<bool>
    {
        public int SpeciesId { get; set; }
        //public ProductTypeDataModel ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public int QuantityInStock { get; set; }
    }
}
