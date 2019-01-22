using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;

namespace PlantDataMVC.WebApi.Helpers
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// Implements sort on IQueryable with string in format (-)field1,(-))field2, etc.
        /// e.g. "-name,count"
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="sort">The sort string.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">source</exception>
        /// <exception cref="ArgumentException">sort</exception>
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string sort)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (sort == null)
            {
                return source;
            }

            // Split sort into fields
            var sortFields = sort.Split(',');

            // Apply ascending or descending order
            for (int i=0; i<sortFields.Length; i++)
            {
                bool sortDescending = false;

                if (sortFields[i].StartsWith("-"))
                {
                    // remove '-'
                    sortFields[i] = sortFields[i].Remove(0,1);
                    sortDescending = true;
                }

                // Expect field string to match property name in source object
                PropertyDescriptor prop = TypeDescriptor.GetProperties(typeof(T)).Find(sortFields[i],true);
                if (prop == null)
                {
                    throw new ArgumentException("sort");
                }

                if (sortDescending)
                {
                    sortFields[i] = sortFields[i] + " desc";
                }
            }

            var sortExpression = string.Join(",", sortFields);

            return source.OrderBy(sortExpression);
        }

        public static IQueryable<T> Paginate<T>(this IQueryable<T> source, int page, int pageSize)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (page < 1)
            {
                // TODO: Do we need to throw arg out of range exception instead?
                page = 1;
            }

            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
