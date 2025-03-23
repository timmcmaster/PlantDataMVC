using Framework.Web.Forms;

namespace PlantData.Web.Blazor.UIModels.EditModels.ProductType
{
    public class ProductTypeCreateEditModel : IForm<bool>
    {
        public string Name { get; set; }
    }
}