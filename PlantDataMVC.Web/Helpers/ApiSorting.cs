using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace PlantDataMVC.Web.Helpers
{
    public static class ApiSorting
    {
        /// <summary>
        /// Creates the sort string.
        /// Currently targeted at just single column sorts (up/down)
        /// </summary>
        /// <param name="sortField">The sort field.</param>
        /// <param name="sortAscending">if set to <c>true</c> [sort ascending].</param>
        /// <returns></returns>
        public static string CreateSortString(string sortField, bool sortAscending)
        {
            var sortString = sortField;

            // NB: If sort is by multi fields, ascending applies to all fields
            if (sortString != "" && !sortAscending)
            {
                var fields = sortString.Split(',');

                for (int i=0; i < fields.Length; i++)
                {
                    fields[i] = "-" + fields[i];
                }

                sortString = string.Join(",", fields);
            }

            return sortString;
        }
    }
}