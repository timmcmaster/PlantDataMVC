using Framework.Service.Entities;
using Interfaces.Domain;
using Interfaces.Service;
using PlantDataMVC.Domain.Entities;
using PlantDataMVC.Service.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace PlantDataMVC.UI.Helpers
{
    /// <summary>
    /// Usage @Html.DropDownFor(() => "ProductType.Id", m => m.ProductType, p => p.DisplayValue, p => p.Id)
    /// </summary>
    public static class DropDownExtensions
    {
        public static MvcHtmlString DropDownFor<TModel, TItem>(this HtmlHelper<TModel> htmlHelper,
            Func<string> fieldName,
            Expression<Func<TModel, TItem>> expression,     // Selects the referenced entity from the model
            Func<TItem, string> displayValueSelector,       // Selects the display field from the entity
            Func<TItem, object> dataValueSelector           // Selects the value field from the entity
            ) where TItem : IDomainEntity
        {
            var expressionText = ExpressionHelper.GetExpressionText(expression);

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var selectedItem = (TItem)metadata.Model;

            // Get list of options from dataService

            // TODO: this doesn't work as IDataServiceBase instances aren't currently registered in IoC
            //var dsTest = DependencyResolver.Current.GetService<IDataServiceBase<TItem>>();

            // This now works after implementing ServiceContract and OperationContract on IDataServiceBase<T> 
            Type interfaceType = GetDataServiceInterfaceFor<TItem>();
            var dataService = DependencyResolver.Current.GetService(interfaceType) as IDataServiceBase<TItem>;
            IList<TItem> items = new List<TItem>();
            if (dataService != null)
            {
                items = dataService.List(new ListRequest<TItem>()).Items;
            }

            var selectListItems = items.Select(x => new SelectListItem
            {
                Text = displayValueSelector(x),
                Value = dataValueSelector(x).ToString(),
                Selected = (dataValueSelector(x).Equals(dataValueSelector(selectedItem)))
            });

            return htmlHelper.DropDownList(fieldName(), selectListItems, "Select an option");
        }

        // HACK: Very very hacky quick hack to return service interface for given IEntity type
        public static Type GetDataServiceInterfaceFor<TItem>() where TItem : IDomainEntity
        {
            if (typeof(TItem) == typeof(Plant))
                return typeof(IPlantDataService);
            //else if (typeof(TItem) == typeof(PlantPriceListType))
            //    return typeof();
            //else if (typeof(TItem) == typeof(PlantProductPrice))
            //    return typeof();
            else if (typeof(TItem) == typeof(PlantProductType))
                return typeof(IPlantProductTypeDataService);
            else if (typeof(TItem) == typeof(PlantSeed))
                return typeof(IPlantSeedDataService);
            else if (typeof(TItem) == typeof(PlantSeedSite))
                return typeof(IPlantSeedSiteDataService);
            else if (typeof(TItem) == typeof(PlantSeedTray))
                return typeof(IPlantSeedTrayDataService);
            else if (typeof(TItem) == typeof(PlantStockEntry))
                return typeof(IPlantStockEntryDataService);
            else if (typeof(TItem) == typeof(PlantStockTransaction))
                return typeof(IPlantStockTransactionDataService);
            else if (typeof(TItem) == typeof(PlantStockTransactionType))
                return typeof(IPlantStockTransactionTypeDataService);
            else
                throw new Exception("corresponding service not found");
        }
    }
}