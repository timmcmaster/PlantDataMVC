//using Framework.Web.Mediator;
using MediatR;
using Framework.Web.Views;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace PlantDataMVC.UICore.Helpers
{
    public static class DropDownExtensions
    {
        // TODO: Implement as below?

        // Preferred call structure would be:
        // @(Html.QueryDropDown2For(() => "SiteId", model => model.Site.Id, new IndexQuery(1, 100), p => p.SiteName, p => p.Id))
        // - requires TViewModel to be inferred somehow (preferably from query type)

        /* Current sample call model for a Genus drop down

         @Html.QueryDropDownFor(
                () => "GenusId",
                model => model.GenusId,
                new ListQuery<GenusDto>(),
                p => p.Id,
                p => p.LatinName)

         */

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
                                                                                     Func<TListItem, string> displayValueSelector
        ) where TListItem : class
          where TViewModel : IEnumerable<TListItem>
        {
            var model = htmlHelper.ViewData.Model;

            //var expressionProvider = new ModelExpressionProvider(htmlHelper.MetadataProvider);
            //var modelExpression = expressionProvider.CreateModelExpression(htmlHelper.ViewData, selectedDataValueExpr);
            //var metadata = modelExpression.Metadata;

            // TODO: Note that this hides the dependency injection to an extent (best to inject mediator if possible)
            IServiceProvider services = htmlHelper.ViewContext.HttpContext.RequestServices;
            
            // Will throw exception if service not registered
            var mediator = services.GetRequiredService<IMediator>();

            // Get list of options via query
            var requestTask = mediator.Send(query);
            // NOTE: Need to be careful with this, as waiting on async can cause deadlocks.
            // ALSO, lose any exception type management, as it returns AggregateException
            var dtoItems = requestTask.Result.OrderBy(x => displayValueSelector(x));

            // Compile expression to use against model
            var selectedDataValue = selectedDataValueExpr.Compile();

            IEnumerable<SelectListItem> selectListItems = dtoItems.Select(x => new SelectListItem
            {
                Text = displayValueSelector(x),
                Value = dataValueSelector(x).ToString(),
                Selected = dataValueSelector(x).Equals(selectedDataValue(model))
            });

            return htmlHelper.DropDownList(saveFieldNameFunc(), selectListItems, "Select an option");
        }
    }
}