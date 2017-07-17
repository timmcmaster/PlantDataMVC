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
            Expression<Func<TModel, TItem>> expression,       // Selects the referenced entity from the model
            Func<TItem, string> displayValueSelector,   // Selects the display field from the entity
            Func<TItem, object> dataValueSelector      // Selects the value field from the entity
            ) where TItem : IDomainEntity
        {
            var expressionText = ExpressionHelper.GetExpressionText(expression);

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var selectedItem = (TItem)metadata.Model;

            // Get list of options from dataService?
            var dataService = DependencyResolver.Current.GetService<IBasicDataService<TItem>>();
            var items = dataService.List(new ListRequest<TItem>()).Items;

            // Get current selected value and displayvalue
            var dataValue = dataValueSelector(selectedItem);
            var displayValue = displayValueSelector(selectedItem);

            // Build list
            var list = new SelectList(items, dataValue);

            // Return list
            return htmlHelper.DropDownList("xyzzy", list);
        }
    }
}