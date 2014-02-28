using System;
using System.Linq.Expressions;
using System.Reflection;

namespace PlantDataMvc3.UI.Helpers
{
    public static class MvcHelperExtensions
    {
        /// <summary>
        /// Extension method for a Type.
        /// Gets the controller name from the Type by removing the "Controller" suffix from the type name.
        /// </summary>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        public static string GetControllerName(this Type controllerType)
        {
            return controllerType.Name.Replace("Controller", string.Empty);
        }

        /// <summary>
        /// Extension method for a LambdaExpression.
        /// Get the action name from a lambda expression that returns an action method.
        /// </summary>
        /// <param name="actionExpression"></param>
        /// <returns></returns>
        public static string GetActionName(this LambdaExpression actionExpression)
        {
            return ((MethodCallExpression)actionExpression.Body).Method.Name;
        }

        /// <summary>
        /// Extension method for a LambdaExpression.
        /// Get the member info (field/property/method) from a lambda expression that returns ???.
        /// </summary>
        /// <param name="actionExpression"></param>
        /// <returns></returns>
        public static MemberInfo GetMember(this LambdaExpression actionExpression)
        {
            var body = actionExpression.Body;
            if (body.NodeType == ExpressionType.Convert)
                body = ((UnaryExpression)body).Operand;

            var memberExpr = body as MemberExpression;

            if (memberExpr != null)
                return memberExpr.Member;

            var callExpr = body as MethodCallExpression;

            if (callExpr != null)
                return callExpr.Method;

            return null;
        }

        /// <summary>
        /// Extension method for a LambdaExpression.
        /// Get the controller type from a lambda expression that returns ???.
        /// </summary>
        /// <param name="actionExpression"></param>
        /// <returns></returns>
        public static Type GetControllerType(this LambdaExpression actionExpression)
        {
            return ((MethodCallExpression)actionExpression.Body).Object.Type;
        }

        /// <summary>
        /// Extension method for a Type.
        /// Gets the area name from the Type by returning the namespace component following "Areas".
        /// </summary>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        public static string GetAreaName(this Type type)
        {
            string[] namespaces = type.Namespace.ToLowerInvariant().Split('.');
            int areaIndex = GetAreaIndex(namespaces);
            if (areaIndex < 0)
            {
                return null;
            }

            return namespaces[areaIndex + 1];
        }

        /// <summary>
        /// Get the index of the "Areas" namespace section in an array of sections.
        /// </summary>
        /// <param name="namespaces"></param>
        /// <returns></returns>
        private static int GetAreaIndex(string[] namespaces)
        {
            for (int i = 0; i < namespaces.Length; i++)
            {
                if (namespaces[i] == "areas")
                {
                    return i;
                }
            }

            return -1;
        }
    }
}