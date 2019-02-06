using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Framework.Web.Mediator;
using Framework.Web.Views;
using PlantDataMVC.UI.Models.ViewModels;

namespace PlantDataMVC.UI.Helpers
{
    public static class DropDownExtensions
    {
        ///// <summary>
        ///// Usage @Html.DropDownFor(() => "ProductType.Id", m => m.ProductType, p => p.DisplayValue, p => p.Id)
        ///// </summary>
        //public static MvcHtmlString DropDownFor<TModel, TDtoItem>(this HtmlHelper<TModel> htmlHelper,
        //    Func<string> fieldName,
        //    Expression<Func<TModel, TDtoItem>> expression,     // Selects the referenced entity from the model
        //    Func<TDtoItem, string> displayValueSelector,       // Selects the display field from the entity
        //    Func<TDtoItem, object> dataValueSelector           // Selects the value field from the entity
        //    ) where TDtoItem : class, IDto
        //{
        //    var expressionText = ExpressionHelper.GetExpressionText(expression);

        //    ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

        //    var selectedItem = (TDtoItem)metadata.Model;

        //    // Get list of options from dataService

        //    // TODO: fix to get corresponding hierarchy in a better way
        //    // This now works after implementing ServiceContract and OperationContract on IDataServiceBase<T>
        //    // Can't get base service directly, as it's not registered with Autofac
        //    //Type interfaceType = GetDataServiceInterfaceFor<TItem>();
        //    //var dataService = DependencyResolver.Current.GetService(interfaceType) as IDataServiceBase<TItem>;

        //    IWcfService dataService = GetServiceForDto<TDtoItem>();

        //    IList<TDtoItem> items = new List<TDtoItem>();
        //    if (dataService != null)
        //    {
        //        items = dataService.List<TDtoItem>().Items;
        //    }

        //    IEnumerable<SelectListItem> selectListItems = items.Select(x => new SelectListItem
        //    {
        //        Text = displayValueSelector(x),
        //        Value = dataValueSelector(x).ToString(),
        //        Selected = dataValueSelector(x).Equals(dataValueSelector(selectedItem))
        //    });

        //    return htmlHelper.DropDownList(fieldName(), selectListItems, "Select an option");
        //}

        /// <summary>
        /// Query drop down for the model.
        /// Usage @Html.DropDownFor(() => "ProductType.Id", new ProductListQuery(),m => m.ProductType, p => p.DisplayValue, p => p.Id)
        /// </summary>
        /// <typeparam name="TModel">The type of the viewmodel for the view.</typeparam>
        /// <typeparam name="TDtoItem">The type of the dto item.</typeparam>
        /// <typeparam name="TQuery">The type of the query.</typeparam>
        /// <param name="htmlHelper">The HTML helper for the page viewmodel (TModel).</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="expression">Selects the referenced item related to this dropdown entity from the model.</param>
        /// <param name="query">The query that returns an enumerable of the dropdown entity type.</param>
        /// <param name="displayValueSelector">Selects the display field from the dropdown entity.</param>
        /// <param name="dataValueSelector">Selects the value field from the dropdown entity</param>
        /// <returns></returns>
        public static MvcHtmlString QueryDropDownFor<TModel, TDtoItem, TQuery>(this HtmlHelper<TModel> htmlHelper,
                                                                               Func<string> fieldName,
                                                                               //Expression<Func<TModel, TDtoItem>> expression,
                                                                               Expression<Func<TModel, TDtoItem>> expression,
                                                                               TQuery query,
                                                                               Func<TDtoItem, string> displayValueSelector,
                                                                               Func<TDtoItem, object> dataValueSelector
        ) where TDtoItem : class, IDto
          where TQuery : IViewQuery<IEnumerable<TDtoItem>>
        {
            var expressionText = ExpressionHelper.GetExpressionText(expression);

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var selectedItem = (TDtoItem)metadata.Model;

            // Get list of options via query,
            var mediator = DependencyResolver.Current.GetService<IMediator>();
            var requestTask = mediator.Request(query);

            requestTask.Wait(); // TODO: Potential deadlock problem

            var dtoItems = requestTask.Result;

            IEnumerable<SelectListItem> selectListItems = dtoItems.Select(x => new SelectListItem
            {
                Text = displayValueSelector(x),
                Value = dataValueSelector(x).ToString(),
                Selected = dataValueSelector(x).Equals(dataValueSelector(selectedItem))
            });

            return htmlHelper.DropDownList(fieldName(), selectListItems, "Select an option");
        }

        /// <summary>
        /// Query drop down for the model.
        /// Usage @Html.DropDownFor(() => "ProductType.Id", new ProductListQuery(),m => m.ProductType, p => p.DisplayValue, p => p.Id)
        /// </summary>
        /// <typeparam name="TModel">The type of the viewmodel for the view.</typeparam>
        /// <typeparam name="TListItem">The type of the dto item.</typeparam>
        /// <typeparam name="TQuery">The type of the query.</typeparam>
        /// <param name="htmlHelper">The HTML helper for the page viewmodel (TModel).</param>
        /// <param name="fieldName">Name of the form field to be used.</param>
        /// <param name="expression">Selects the referenced item related to this dropdown entity from the model.</param>
        /// <param name="query">The query that returns an enumerable of the dropdown entity type.</param>
        /// <param name="displayValueSelector">Selects the display field from the dropdown entity.</param>
        /// <param name="dataValueSelector">Selects the value field from the dropdown entity</param>
        /// <returns></returns>
        public static MvcHtmlString QueryDropDown2For<TModel, TListItem, TQuery>(this HtmlHelper<TModel> htmlHelper,
                                                                                 TListItem sampleItem,
                                                                               Func<string> fieldName,
                                                                               Expression<Func<TModel, object>> selectedDataValue,
                                                                               TQuery query,
                                                                               Func<TListItem, string> displayValueSelector,
                                                                               Func<TListItem, object> dataValueSelector
        ) where TListItem : class
          where TQuery : IViewQuery<ListViewModelStatic<TListItem>>
        {
            // Get list of options via query
            var mediator = DependencyResolver.Current.GetService<IMediator>();
            var requestTask = mediator.Request(query);
            requestTask.Wait();
            var dtoItems = requestTask.Result;

            IEnumerable<SelectListItem> selectListItems = dtoItems.Select(x => new SelectListItem
            {
                Text = displayValueSelector(x),
                Value = dataValueSelector(x).ToString(),
                Selected = dataValueSelector(x).Equals(selectedDataValue)
            });

            return htmlHelper.DropDownList(fieldName(), selectListItems, "Select an option");
        }

    }
}