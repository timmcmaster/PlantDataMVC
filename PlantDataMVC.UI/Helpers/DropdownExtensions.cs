using Interfaces.DTO;
using Interfaces.WcfService;
using PlantDataMVC.WCFService.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using PlantDataMVC.DTO.Dtos;

namespace PlantDataMVC.UI.Helpers
{
    /// <summary>
    /// Usage @Html.DropDownFor(() => "ProductType.Id", m => m.ProductType, p => p.DisplayValue, p => p.Id)
    /// </summary>
    public static class DropDownExtensions
    {
        public static MvcHtmlString DropDownFor<TModel, TDtoItem>(this HtmlHelper<TModel> htmlHelper,
            Func<string> fieldName,
            Expression<Func<TModel, TDtoItem>> expression,     // Selects the referenced entity from the model
            Func<TDtoItem, string> displayValueSelector,       // Selects the display field from the entity
            Func<TDtoItem, object> dataValueSelector           // Selects the value field from the entity
            ) where TDtoItem : class, IDto
        {
            var expressionText = ExpressionHelper.GetExpressionText(expression);

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var selectedItem = (TDtoItem)metadata.Model;

            // Get list of options from dataService

            // TODO: fix to get corresponding hierarchy in a better way
            // This now works after implementing ServiceContract and OperationContract on IDataServiceBase<T>
            // Can't get base service directly, as it's not registered with Autofac
            //Type interfaceType = GetDataServiceInterfaceFor<TItem>();
            //var dataService = DependencyResolver.Current.GetService(interfaceType) as IDataServiceBase<TItem>;

            IWcfService dataService = GetServiceForDto<TDtoItem>();

            IList<TDtoItem> items = new List<TDtoItem>();
            if (dataService != null)
            {
                items = dataService.List<TDtoItem>().Items;
            }

            IEnumerable<SelectListItem> selectListItems = items.Select(x => new SelectListItem
            {
                Text = displayValueSelector(x),
                Value = dataValueSelector(x).ToString(),
                Selected = dataValueSelector(x).Equals(dataValueSelector(selectedItem))
            });

            return htmlHelper.DropDownList(fieldName(), selectListItems, "Select an option");
        }

        // HACK: Still very hacky quick method to return service interface for given IDto type
        public static IWcfService GetServiceForDto<TDtoItem>() where TDtoItem : IDto
        {
            // TODO: Add all DTO types used by dropdown in here
            if (typeof(TDtoItem) == typeof(GenusDto))
                return GetServiceFor<IGenusWcfService>();
            //else if (typeof(TItem) == typeof(PlantPriceListType))
            //    return typeof();
            //else if (typeof(TItem) == typeof(PlantProductPrice))
            //    return typeof();
            else if (typeof(TDtoItem) == typeof(SpeciesDto))
                return GetServiceFor<ISpeciesWcfService>();
            else if (typeof(TDtoItem) == typeof(ProductTypeDto))
                return GetServiceFor<IProductTypeWcfService>();
            else if (typeof(TDtoItem) == typeof(SeedBatchDto))
                return GetServiceFor<ISeedBatchWcfService>();
            else if (typeof(TDtoItem) == typeof(SiteDto))
                return GetServiceFor<ISiteWcfService>();
            else if (typeof(TDtoItem) == typeof(SeedTrayDto))
                return GetServiceFor<ISeedTrayWcfService>();
            else if (typeof(TDtoItem) == typeof(PlantStockDto))
                return GetServiceFor<IPlantStockWcfService>();
            else if (typeof(TDtoItem) == typeof(JournalEntryDto))
                return GetServiceFor<IJournalEntryWcfService>();
            else if (typeof(TDtoItem) == typeof(JournalEntryTypeDto))
                return GetServiceFor<IJournalEntryTypeWcfService>();
            else
                throw new Exception("corresponding service not found");
        }

        public static IWcfService GetServiceFor<TInterface>()
        {
            return DependencyResolver.Current.GetService<TInterface>() as IWcfService;
        }
    }
}