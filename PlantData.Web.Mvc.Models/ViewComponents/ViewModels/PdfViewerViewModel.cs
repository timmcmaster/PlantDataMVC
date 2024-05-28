using PlantData.Web.Mvc.Models.ViewModels.Label;

namespace PlantData.Web.Mvc.Models.ViewComponents.ViewModels
{
    public class PdfViewerViewModel
    {
        public FileModel FileToView { get; set; } = new();
        public string Width { get; set; } = string.Empty;
        public string Height { get; set; } = string.Empty;
    }
}
