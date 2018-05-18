using Framework.Service.Entities;
using Interfaces.Domain;
using Interfaces.Service;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

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
            var dataService = DependencyResolver.Current.GetService<IDataServiceBase<TItem>>();
            var items = dataService.List(new ListRequest<TItem>()).Items;

            var selectListItems = items.Select(x => new SelectListItem
            {
                Text = displayValueSelector(x),
                Value = dataValueSelector(x).ToString(),
                Selected = (dataValueSelector(x).Equals(dataValueSelector(selectedItem)))
            });

            return htmlHelper.DropDownList(fieldName(), selectListItems,"Select an option");
        }
    }
}