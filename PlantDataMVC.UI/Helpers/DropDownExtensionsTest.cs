using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Framework.Web.Mediator;
using Framework.Web.Views;
using PlantDataMVC.UI.Controllers.Queries;
using PlantDataMVC.UI.Models.ViewModels;

namespace PlantDataMVC.UI.Helpers
{
    public static class DropDownExtensionsTest
    {
        // Preferred call structure would be:
        // @(Html.QueryDropDownFor(() => "SiteId", model => model.Site.Id, new SiteIndexQuery(1, 100), p => p.SiteName, p => p.Id))
        // - requires TViewModel to be inferred somehow (preferably from query type)

        public static MvcHtmlString QueryDropdownFor<TModel, TViewModel, TListItem>(this HtmlHelper<TModel> htmlHelper,
                                                                                    Func<string> saveFieldNameFunc,
                                                                                    Expression<Func<TModel, object>>
                                                                                        selectedDataValue,
                                                                                    IViewQueryForList<TListItem,
                                                                                        TViewModel> query,
                                                                                    Func<TListItem, string>
                                                                                        displayValueSelector,
                                                                                    Func<TListItem, object>
                                                                                        dataValueSelector
        ) where TListItem : class
          where TViewModel : IEnumerable<TListItem>
        {
            // Get list of options via query
            var mediator = DependencyResolver.Current.GetService<IMediator>();
            var requestTask = mediator.Request(query);
            // NOTE: Need to be careful with this, as waiting on async can cause deadlocks.
            // ALSO, lose any exception type management, as it returns AggregateException
            var dtoItems = requestTask.Result;

            var selectListItems =
                CreateSelectList(dtoItems, displayValueSelector, dataValueSelector, selectedDataValue);

            return htmlHelper.DropDownList(saveFieldNameFunc(), selectListItems, "Select an option");
        }


        public static IEnumerable<SelectListItem> CreateSelectList<TListItem>(
            IEnumerable<TListItem> viewModel,
            Func<TListItem, string> displayValueSelector,
            Func<TListItem, object> dataValueSelector,
            object selectedDataValue)
        {
            var selectListItems = viewModel.Select(x => new SelectListItem
            {
                Text = displayValueSelector(x),
                Value = dataValueSelector(x).ToString(),
                Selected = dataValueSelector(x).Equals(selectedDataValue)
            });

            return selectListItems;
        }

        public static void TestMethod()
        {
            var query = new SiteIndexQuery(1, 100);

            var selectList = DropdownBuilder<;

            //var selectList = slb.Build()

        }
    }

    public class DropdownBuilder<TLi>
    {

    }
    // Other Classes
    public class DropdownBuilder<TViewModel,TListItem> where TViewModel : IEnumerable<TListItem>
    {
        public static IEnumerable<SelectListItem> Build(IViewQuery<TViewModel> query, 
                                                        Func<TListItem, string> displayValueSelector,
                                                        Func<TListItem, object> dataValueSelector,
                                                        object selectedDataValue)
        {
            // Get list of options via query
            var mediator = DependencyResolver.Current.GetService<IMediator>();
            var requestTask = mediator.Request(query);
            // NOTE: Need to be careful with this, as waiting on async can cause deadlocks.
            // ALSO, lose any exception type management, as it returns AggregateException
            var dtoItems = requestTask.Result;

            return SelectListBuilder<TListItem>.Build((IEnumerable<TListItem>)dtoItems, displayValueSelector, dataValueSelector, selectedDataValue);
        }
    }

    public class SelectListBuilder<TListItem>
    {
        public static IEnumerable<SelectListItem> Build(
            IEnumerable<TListItem> viewModel,
            Func<TListItem, string> displayValueSelector,
            Func<TListItem, object> dataValueSelector,
            object selectedDataValue)
        {
            var selectListItems = viewModel.Select(x => new SelectListItem
            {
                Text = displayValueSelector(x),
                Value = dataValueSelector(x).ToString(),
                Selected = dataValueSelector(x).Equals(selectedDataValue)
            });

            return selectListItems;
        }
    }
}