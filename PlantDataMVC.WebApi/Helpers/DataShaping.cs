using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using Interfaces.DTO;

namespace PlantDataMVC.WebApi.Helpers
{
    public static class DataShaping
    {
        /// <summary>
        /// Creates the data shaped object.
        /// </summary>
        /// <typeparam name="TDto">The type of the dto.</typeparam>
        /// <param name="dto">The dto.</param>
        /// <param name="fieldList">The field list.</param>
        /// <param name="childrenToInclude"></param>
        /// <returns></returns>
        public static object CreateDataShapedObject<TDto>(TDto dto, List<string> fieldList, List<string> childrenToInclude) where TDto : IDto
        {
            if (!fieldList.Any())
            {
                return dto;
            }
            else
            {
                // TODO: get DTO for 
                // Strip out any child fields from list of fields
                List<string> fieldsOfChildren = fieldList.Where(f => f.Contains('.')).ToList();

                // Determine fields for each specific child object
                foreach (string childName in childrenToInclude)
                {
                    List<string> thisChildFields = fieldsOfChildren.Where(f => f.ToLower().StartsWith(childName.ToLower())).ToList();

                    // Strip childName and "." from list of fields
                    thisChildFields = thisChildFields.Select(f => f.Substring(f.IndexOf(".") + 1)).ToList();

                    // Get DTO for child object

                    // Create data shaped object for child and add to corresponding collection for this object
                    var childShapedObject = CreateDataShapedObject<TDto>()
                }

                // create a new ExpandoObject & dynamically create the properties for this object
                ExpandoObject objectToReturn = new ExpandoObject();
                foreach (var field in fieldList)
                {
                    var fieldType = dto.GetType();

                    // need to include public and instance, b/c specifying a binding flag overwrites the
                    // already-existing binding flags.
                    var fieldPropInfo = fieldType.GetProperty(field,
                        BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                    var fieldValue = fieldPropInfo.GetValue(dto, null);

                    // add the field to the ExpandoObject with the actual property name from the object
                    ((IDictionary<string, object>) objectToReturn).Add(fieldPropInfo.Name, fieldValue);
                }

                return objectToReturn;
            }
        }

        /// <summary>
        /// Gets the child objects to include.
        /// </summary>
        /// <param name="childObjects">The child objects.</param>
        /// <param name="lstOfFields">The LST of fields.</param>
        /// <returns></returns>
        public static List<string> GetChildObjectsToInclude(List<string> childObjects, List<string> lstOfFields)
        {
            var childObjectsToInclude = new List<string>();

            // quick check for included child DTOs
            foreach (var childName in childObjects)
            {
                if (lstOfFields.Any(f => f.Contains(childName)))
                {
                    childObjectsToInclude.Add(childName);
                }
            }

            return childObjectsToInclude;
        }
    }
}