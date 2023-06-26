//using Framework.Web.Mediator;
using Framework.Web.Services;
using Framework.Web.Views;
using MediatR;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PlantDataMVC.Web.Helpers
{
    public static class DropDownExtensions
    {
        public static IHtmlContent QueryDropDownFor<TModel, TViewModel, TListItem, TProperty>(this IHtmlHelper<TModel> htmlHelper,
                                                                                     Func<string> saveFieldNameFunc,
                                                                                     Expression<Func<TModel, TProperty>> selectedDataValueExpr,
                                                                                     IQueryForList<TListItem, TViewModel> query,
                                                                                     Func<TListItem, TProperty> dataValueSelector,
                                                                                     Func<TListItem, string> displayValueSelector
        ) where TListItem : class
          where TViewModel : IEnumerable<TListItem>
        { 
            return QueryDropDownFor(htmlHelper, saveFieldNameFunc, selectedDataValueExpr, query, dataValueSelector, displayValueSelector, new { });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TViewModel"></typeparam>
        /// <typeparam name="TListItem"></typeparam>
        /// <param name="htmlHelper">HtmlHelper</param>
        /// <param name="saveFieldNameFunc">A function that returns the fieldname string for the field to hold the result</param>
        /// <param name="selectedDataValueExpr">A function that returns the current value from the model</param>
        /// <param name="query">The query to send to the mediator</param>
        /// <param name="dataValueSelector">The function to select the data value from the DTO the query returns</param>
        /// <param name="displayValueSelector">The function to select the display value from the DTO the query returns</param>
        /// <returns></returns>
        public static IHtmlContent QueryDropDownFor<TModel, TViewModel, TListItem, TProperty>(this IHtmlHelper<TModel> htmlHelper,
                                                                                     Func<string> saveFieldNameFunc,
                                                                                     Expression<Func<TModel, TProperty>> selectedDataValueExpr,
                                                                                     IQueryForList<TListItem, TViewModel> query,
                                                                                     Func<TListItem, TProperty> dataValueSelector,
                                                                                     Func<TListItem, string> displayValueSelector,
                                                                                     object htmlAttributes
        ) where TListItem : class
          where TViewModel : IEnumerable<TListItem>
        {
            var model = htmlHelper.ViewData.Model;

            // HACK: Note that this hides the dependency injection to an extent (best to inject mediator if possible)
            IServiceProvider services = htmlHelper.ViewContext.HttpContext.RequestServices;
            
            // Will throw exception if service not registered
            var lookupService = services.GetRequiredService<ILookupService<TListItem>>();
            var lookupItems = lookupService.GetOrderedData(x => displayValueSelector(x));

            // Compile expression to use against model
            var selectedDataValue = selectedDataValueExpr.Compile();

            IEnumerable<SelectListItem> selectListItems = lookupItems.Select(x => new SelectListItem
            {
                Text = displayValueSelector(x),
                Value = dataValueSelector(x).ToString(),
                Selected = dataValueSelector(x).Equals(selectedDataValue(model))
            });

            return htmlHelper.DropDownList(saveFieldNameFunc(), selectListItems, "Select an option", htmlAttributes);
        }
    }
}