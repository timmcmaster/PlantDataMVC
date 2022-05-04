using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework.Web.Core.Mediator;
using Framework.Web.Core.Views;

namespace PlantDataMVC.UI.Helpers
{
    public static class DropDownExtensions
    {
        // Preferred call structure would be:
        // @(Html.QueryDropDown2For(() => "SiteId", model => model.Site.Id, new IndexQuery(1, 100), p => p.SiteName, p => p.Id))
        // - requires TViewModel to be inferred somehow (preferably from query type)
        public static MvcHtmlString QueryDropDownFor<TModel, TViewModel, TListItem>(this HtmlHelper<TModel> htmlHelper,
                                                                                     Func<string> saveFieldNameFunc,
                                                                                     Expression<Func<TModel, object>>
                                                                                         selectedDataValue,
                                                                                     IQueryForList<TListItem,
                                                                                         TViewModel> query,
                                                                                     Func<TListItem, object>
                                                                                         dataValueSelector,
                                                                                     Func<TListItem, string>
                                                                                         displayValueSelector
        ) where TListItem : class
          where TViewModel : IEnumerable<TListItem>
        {
            // Get list of options via query
            var mediator = DependencyResolver.Current.GetService<IMediator>();
            var requestTask = mediator.Request(query);
            // NOTE: Need to be careful with this, as waiting on async can cause deadlocks.
            // ALSO, lose any exception type management, as it returns AggregateException
            var dtoItems = requestTask.Result;

            IEnumerable<SelectListItem> selectListItems = dtoItems.Select(x => new SelectListItem
            {
                Text = displayValueSelector(x),
                Value = dataValueSelector(x).ToString(),
                Selected = dataValueSelector(x).Equals(selectedDataValue)
            });

            return htmlHelper.DropDownList(saveFieldNameFunc(), selectListItems, "Select an option");
        }
    }
}