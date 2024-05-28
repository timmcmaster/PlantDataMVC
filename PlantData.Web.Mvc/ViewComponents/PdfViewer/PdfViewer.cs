using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantData.Web.Mvc.Models.ViewModels.Label;
using PlantData.Web.Mvc.Models.ViewComponents.ViewModels;
using System;
using System.Threading.Tasks;

namespace PlantData.Web.Mvc.ViewComponents.PdfViewer
{
    public class PdfViewer : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public PdfViewer(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public IViewComponentResult Invoke(FileModel fileModel, string width, string height)
        {
            string viewName = "Default";

            if (_useBasicMvcViews)
                viewName = "Basic";

            var viewModel = new PdfViewerViewModel()
            {
                FileToView = fileModel,
                Width = width,
                Height = height
            };

            return View(viewName, viewModel);
        }
    }
}
