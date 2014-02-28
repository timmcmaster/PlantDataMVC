using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

//// Code copied from....
//// Type: Rhino.Mocks.Constraints.AllPropertiesMatchConstraint
//// Assembly: Rhino.Mocks.dll
//// Assembly: Rhino.Mocks, Version=3.6.0.0, Culture=neutral, PublicKeyToken=0b3305902db7183f

namespace UnitTest.Utils
{
    internal class AllPropertiesMatch
    {
        #region Constants and Fields

        private readonly List<object> checkedObjects;
        private readonly object expectedObject;
        private readonly Stack<string> properties;
        private string message;

        #endregion

        #region Constructors and Destructors

        public AllPropertiesMatch(object expected)
        {
            this.expectedObject = expected;
            properties = new Stack<string>();
            checkedObjects = new List<object>();
        }

        #endregion

        #region Properties

        public string Message
        {
            get { return message; }
        }

        #endregion

        #region Public Methods

        public bool Eval(object obj)
        {
            properties.Clear();
            checkedObjects.Clear();
            properties.Push(obj.GetType().Name);
            bool flag = CheckReferenceType(expectedObject, obj);
            properties.Pop();
            checkedObjects.Clear();
            return flag;
        }

        #endregion

        #region Methods

        protected virtual bool CheckFields(object expected, object actual)
        {
            Type type = expected.GetType();
            actual.GetType();
            checkedObjects.Add(actual);
            foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.Public))
            {
                properties.Push(fieldInfo.Name);
                bool flag = CheckValue(fieldInfo.GetValue(expected), fieldInfo.GetValue(actual));
                properties.Pop();
                if (!flag)
                {
                    return false;
                }
            }

            return true;
        }

        protected virtual bool CheckProperties(object expected, object actual)
        {
            Type type = expected.GetType();
            actual.GetType();
            foreach (PropertyInfo propertyInfo in type.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (propertyInfo.GetIndexParameters().Length == 0)
                {
                    properties.Push(propertyInfo.Name);
                    try
                    {
                        if (!CheckValue(propertyInfo.GetValue(expected, null), propertyInfo.GetValue(actual, null)))
                        {
                            return false;
                        }
                    }
                    catch (TargetInvocationException ex)
                    {
                    }

                    properties.Pop();
                }
            }

            return true;
        }

        protected virtual bool CheckReferenceType(object expected, object actual)
        {
            Type type1 = expected.GetType();
            Type type2 = actual.GetType();
            if (type1 == type2)
            {
                return CheckValue(expected, actual);
            }

            message = string.Format("Expected type '{0}' doesn't match with actual type '{1}'", type1.Name, type2.Name);
            return false;
        }

        protected virtual bool CheckValue(object expected, object actual)
        {
            if (actual == null && expected != null)
            {
                message = string.Format(
                    "Expected value of {0} is '{1}', actual value is null", BuildPropertyName(), expected);
                return false;
            }
            else
            {
                if (expected == null)
                {
                    if (actual != null)
                    {
                        message = string.Format(
                            "Expected value of {0} is null, actual value is '{1}'", BuildPropertyName(), actual);
                        return false;
                    }
                }
                else if (expected is IComparable)
                {
                    if (!expected.Equals(actual))
                    {
                        message = string.Format(
                            "Expected value of {0} is '{1}', actual value is '{2}'",
                            BuildPropertyName(),
                            expected,
                            actual);
                        return false;
                    }
                }
                else if (expected is IEnumerable)
                {
                    if (!CheckCollection((IEnumerable)expected, (IEnumerable)actual))
                    {
                        return false;
                    }
                }
                else if (!checkedObjects.Contains(expected))
                {
                    checkedObjects.Add(expected);
                    if (!CheckProperties(expected, actual) || !CheckFields(expected, actual))
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        private string BuildPropertyName()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string str in properties.ToArray())
            {
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Insert(0, '.');
                }

                stringBuilder.Insert(0, str);
            }

            return stringBuilder.ToString();
        }

        private bool CheckCollection(IEnumerable expectedCollection, IEnumerable actualCollection)
        {
            if (expectedCollection != null)
            {
                IEnumerator enumerator1 = expectedCollection.GetEnumerator();
                IEnumerator enumerator2 = actualCollection.GetEnumerator();
                bool flag1 = enumerator1.MoveNext();
                bool flag2 = enumerator2.MoveNext();
                int num1 = 0;
                int num2 = 0;
                string str = properties.Pop();
                for (; flag1 && flag2; flag2 = enumerator2.MoveNext())
                {
                    object current1 = enumerator1.Current;
                    object current2 = enumerator2.Current;
                    properties.Push(str + string.Format("[{0}]", num1));
                    ++num1;
                    ++num2;
                    if (!CheckReferenceType(current1, current2))
                    {
                        return false;
                    }

                    properties.Pop();
                    flag1 = enumerator1.MoveNext();
                }

                properties.Push(str);
                if (flag1 & !flag2)
                {
                    do
                    {
                        ++num1;
                    }
                    while (enumerator1.MoveNext());
                }

                if (!flag1 & flag2)
                {
                    do
                    {
                        ++num2;
                    }
                    while (enumerator2.MoveNext());
                }

                if (num1 != num2)
                {
                    message = string.Format(
                        "expected number of items in collection {0} is '{1}', actual is '{2}'",
                        BuildPropertyName(),
                        num1,
                        num2);
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}