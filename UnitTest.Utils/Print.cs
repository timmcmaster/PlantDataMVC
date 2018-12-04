using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using Xunit;
using Xunit.Abstractions;

namespace UnitTest.Utils
{
    public static class Print
    {
        public static void PrintTypeAndProperties(ITestOutputHelper output, object obj)
        {
            Type type = obj.GetType();
            output.WriteLine("Parent Object Type: {0}", type.ToString());

            PropertyInfo[] props = type.GetProperties();

            foreach (PropertyInfo p in props)
            {
                if ((p.PropertyType.IsPrimitive) || (p.PropertyType == typeof(String)))
                {
                    output.WriteLine("{0}: {1}", p.Name, p.GetValue(obj, null));
                }
                else
                {
                    output.WriteLine("{0}: {1} Type: {2}", p.Name, "(value unknown)", p.PropertyType.ToString());
                }
            }
        }

    }
}
