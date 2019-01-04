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

            // TODO: fix to get corresponding hierarchy in a better way
            // This now works after implementing ServiceContract and OperationContract on IDataServiceBase<T>
            // Can't get base service directly, as it's not registered with Autofac
            //Type interfaceType = GetDataServiceInterfaceFor<TItem>();
            //var dataService = DependencyResolver.Current.GetService(interfaceType) as IDataServiceBase<TItem>;

            var dataService = GetServiceFor<TItem>();

            IList<TItem> items = new List<TItem>();
            if (dataService != null)
            {
                items = dataService.List().Items;
            }

            var selectListItems = items.Select(x => new SelectListItem
            {
                Text = displayValueSelector(x),
                Value = dataValueSelector(x).ToString(),
                Selected = (dataValueSelector(x).Equals(dataValueSelector(selectedItem)))
            });

            return htmlHelper.DropDownList(fieldName(), selectListItems, "Select an option");
        }

        // HACK: Still very hacky quick method to return service interface for given IEntity type
        public static IDataServiceBase<TItem> GetServiceFor<TItem>() where TItem : IDomainEntity
        {
            if (typeof(TItem) == typeof(Plant))
                return GetServiceFor<TItem, IPlantDataService>();
            //else if (typeof(TItem) == typeof(PlantPriceListType))
            //    return typeof();
            //else if (typeof(TItem) == typeof(PlantProductPrice))
            //    return typeof();
            else if (typeof(TItem) == typeof(PlantProductType))
                return GetServiceFor<TItem, IPlantProductTypeDataService>();
            else if (typeof(TItem) == typeof(PlantSeed))
                return GetServiceFor<TItem, IPlantSeedDataService>();
            else if (typeof(TItem) == typeof(PlantSeedSite))
                return GetServiceFor<TItem, IPlantSeedSiteDataService>();
            else if (typeof(TItem) == typeof(PlantSeedTray))
                return GetServiceFor<TItem, IPlantSeedTrayDataService>();
            else if (typeof(TItem) == typeof(PlantStockEntry))
                return GetServiceFor<TItem, IPlantStockEntryDataService>();
            else if (typeof(TItem) == typeof(PlantStockTransaction))
                return GetServiceFor<TItem, IPlantStockTransactionDataService>();
            else if (typeof(TItem) == typeof(PlantStockTransactionType))
                return GetServiceFor<TItem, IPlantStockTransactionTypeDataService>();
            else
                throw new Exception("corresponding service not found");
        }

        public static IDataServiceBase<TItem> GetServiceFor<TItem, TInterface>() where TItem : IDomainEntity
        {
            return DependencyResolver.Current.GetService<TInterface>() as IDataServiceBase<TItem>;
        }
    }
}