using System.ComponentModel;

namespace PlantData.Web.Blazor.UIModels.ViewModels.Genus
{
    public class GenusGridModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Latin Name")]
        public string LatinName { get; set; }
    }
}
