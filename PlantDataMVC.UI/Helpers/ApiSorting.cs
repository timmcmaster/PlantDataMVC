namespace PlantDataMVC.UI.Helpers
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

            if (sortString != "" && !sortAscending)
            {
                sortString = "-" + sortString;
            }

            return sortString;
        }
    }
}