using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Linq.Expressions;
using System.Web.Routing;
using System.Reflection;
using Framework.Service.ServiceLayer;
using Framework.Domain;

namespace PlantDataMVC.UI.Helpers
{
    /// <summary>
    /// Usage @Html.DropDownFor(m => m.ProductType, t => t.DisplayValue, t => t.Id)
    /// </summary>
    public static class DropDownExtensions
    {
        public static MvcHtmlString DropDownFor<TModel,TItem>(this HtmlHelper<TModel> htmlHelper,
            Func<string> fieldName,
            Expression<Func<TModel, TItem>> expression,       // Selects the referenced entity from the model
            Func<TItem, string> displayValueSelector,   // Selects the display field from the entity
            Func<TItem, object> dataValueSelector      // Selects the value field from the entity
            ) where TItem : IDomainEntity
        {
            var expressionText = ExpressionHelper.GetExpressionText(expression);

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var selectedItem = (TItem)metadata.Model;

            // Get list of options from dataService
            var dataService = DependencyResolver.Current.GetService<IBasicDataService<TItem>>();
            var items = dataService.List(new ListRequest<TItem>()).Items;

            var selectListItems = GetItems(items, displayValueSelector, dataValueSelector, selectedItem);

            return htmlHelper.DropDownList(fieldName(), selectListItems); 
        }

        /// <summary>
        /// Convert a collection of generic items to a collection of SelectListItems 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="displayValueSelector"></param>
        /// <param name="dataValueSelector"></param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> GetItems<T>(IEnumerable<T> items, Func<T, string> displayValueSelector, Func<T,object> dataValueSelector, T selectedItem)
        {
            //var listItems = items.Select(x => new SelectListItem
            //    {
            //        Text = displayValueSelector(x),
            //        Value = dataValueSelector(x).ToString()
            //    });

            var listItems = new List<SelectListItem>();
            foreach (var item in items)
            {
                listItems.Add(new SelectListItem
                {
                    Text = displayValueSelector(item),
                    Value = dataValueSelector(item).ToString(),
                    Selected = (dataValueSelector(item).Equals(dataValueSelector(selectedItem)))
                });
            }

            return new SelectList(listItems);
        }
    }
}