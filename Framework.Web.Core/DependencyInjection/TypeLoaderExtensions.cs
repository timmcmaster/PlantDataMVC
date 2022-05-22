using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;

namespace Framework.Web.Core.DependencyInjection
{
    public static class TypeLoaderExtensions
    {
        /// <summary>
        /// From https://stackoverflow.com/questions/26733/getting-all-types-that-implement-an-interface
        /// and http://haacked.com/archive/2012/07/23/get-all-types-in-an-assembly.aspx/
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }
    }
}