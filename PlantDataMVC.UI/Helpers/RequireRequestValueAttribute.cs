using System.Reflection;
using System.Web.Mvc;

namespace PlantDataMVC.UI.Helpers
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

        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return controllerContext.HttpContext.Request[ValueName] != null;
        }

        public string ValueName { get; }
    }
}
