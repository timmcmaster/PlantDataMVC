using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Utils
{
    [DebuggerStepThrough]
    public static class AssertProperties
    {
        /// <summary>
        /// Checks if two objects are equal by comparing there parameters 
        /// </summary>
        /// <param name="expected">expected object</param>
        /// <param name="actual">actual object</param>
        /// <returns>true if objects equal</returns>
        [DebuggerStepThrough]
        public static void PropertiesAreEqual(object expected, object actual)
        {
            var propsMatch = new AllPropertiesMatch(expected);
      
            if (!propsMatch.Eval(actual))
            {
                throw new AssertFailedException(propsMatch.Message);
            }
        }
    }
}
