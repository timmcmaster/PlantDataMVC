using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Framework.Web.Mvc
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

            switch (body)
            {
                case MemberExpression memberExpr:
                    return memberExpr.Member;
                case MethodCallExpression callExpr:
                    return callExpr.Method;
                default:
                    return null;
            }
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
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetAreaName(this Type type)
        {
            var namespaces = type.Namespace.ToLowerInvariant().Split('.');
            var areaIndex = GetAreaIndex(namespaces);
            return areaIndex < 0 ? null : namespaces[areaIndex + 1];
        }

        /// <summary>
        /// Get the index of the "Areas" namespace section in an array of sections.
        /// </summary>
        /// <param name="namespaces"></param>
        /// <returns></returns>
        private static int GetAreaIndex(string[] namespaces)
        {
            for (var i = 0; i < namespaces.Length; i++)
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