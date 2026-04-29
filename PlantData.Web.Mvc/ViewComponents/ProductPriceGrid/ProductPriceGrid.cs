using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PlantData.Web.Mvc.Models.ViewComponents.ViewModels;
using PlantData.Web.Mvc.Models.ViewModels.ProductPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantData.Web.Mvc.ViewComponents.ProductPriceGrid
{
    public class ProductPriceGrid : ViewComponent
    {
        private readonly bool _UseBasicHtmlViews = false;

        public ProductPriceGrid(IConfiguration configuration)
        {
            _UseBasicHtmlViews = Convert.ToBoolean(configuration["WebUI:UseBasicHtmlViews"]);
        }

        public IViewComponentResult Invoke(IEnumerable<ProductPriceListViewModel> productPrices, DateTime effectiveDate, GridOptionsModel gridOptions, int? priceListTypeId = null)
        {
            string viewName = "Default";

            if (_UseBasicHtmlViews)
            {
                viewName = "Basic";
            }

            var productsByLastUpToEffectiveDate = productPrices.Where(x => x.DateEffective <= effectiveDate)
                .GroupBy(y => y.ProductTypeId)
                .Select(g => g.OrderByDescending(y => y.DateEffective).First())
                .ToList();

            var gridModel = new ProductPriceGridViewModel()
            {
                Options = gridOptions,

                //PageNumber = model.PageNumber,
                //PageSize = model.PageSize,
                //HasNextPage = model.HasNextPage,
                //HasPreviousPage = model.HasPreviousPage,
                //TotalCount = model.TotalCount,
                //TotalPages = model.TotalPages,

                //SortBy = model.SortBy,
                //SortAscending = model.SortAscending,
                //SortExpression = model.SortExpression,

                PriceListTypeId = priceListTypeId,
                EffectiveDate = effectiveDate,
                Items = productsByLastUpToEffectiveDate
            };

            return View(viewName, gridModel);
        }
    }
}
