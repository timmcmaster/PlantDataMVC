using Framework.Web.Forms;

namespace PlantData.Web.Mvc.Models.EditModels.ProductType
{
    public class ProductTypeDestroyEditModel : IForm<bool>
    {
        public int Id { get; set; }
    }
}