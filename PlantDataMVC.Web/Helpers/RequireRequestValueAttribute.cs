using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;

namespace PlantDataMVC.Web.Helpers
{
    /// <summary>
    /// Implements method overloading via attribute based on parameter name in request
    /// Called as <code>[RequireRequestValue("speciesId")]</code>
    /// </summary>
    public class RequireRequestValueAttribute : ActionMethodSelectorAttribute
    {
        public RequireRequestValueAttribute(string valueName)
        {
            ValueName = valueName;
        }

        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            // TODO: Check that the top line corresponds to old line below
            return routeContext.HttpContext.Request.RouteValues.ContainsKey(ValueName);
            //return routeContext.HttpContext.Request[ValueName] != null;
        }

        public string ValueName { get; }
    }
}
