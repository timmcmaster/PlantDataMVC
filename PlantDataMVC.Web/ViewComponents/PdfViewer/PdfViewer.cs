using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantDataMvc.Web.Models.ViewComponents.ViewModels;
using System;
using System.Threading.Tasks;

namespace PlantDataMVC.Web.ViewComponents.PdfViewer
{
    public class PdfViewer : ViewComponent
    {
        private readonly bool _useBasicMvcViews = false;

        public PdfViewer(IConfiguration configuration)
        {
            _useBasicMvcViews = Convert.ToBoolean(configuration["WebUI:UseBasicMvcViews"]);
        }

        public async Task<IViewComponentResult> InvokeAsync(string width, string height)
        {
            string viewName = "Default";

            if (_useBasicMvcViews)
                viewName = "Basic";

            var viewModel = new PdfViewerViewModel()
            {
                Width = width,
                Height = height
            };

            return View(viewName, viewModel);
        }
    }
}
