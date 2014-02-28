using System.Data.Entity;
using PlantDataMvc3.DAL.LinqToSql.Entities;
using System.Data.Linq;

namespace PlantDataMvc3.DAL.LinqToSql.Infrastructure
{
    /// <summary>
    /// This is the central class for managing access to the Data Context.
    /// Implements the singleton pattern to ensure we only ever have one manager and Context.
    /// </summary>
    public class ContextManager
    {
        private static ContextManager _manager;
        private static DataContext _dataContext;

        /// <summary>
        /// 
        /// </summary>
        private ContextManager()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ContextManager Instance()
        {
            if (_manager == null)
            {
                _manager = new ContextManager();
            }

            return _manager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static ITable<T> GetTable<T>(T entity)
            where T : class
        {
            return Instance().GetDataContext().GetTable<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal DataContext GetDataContext()
        {
            if (_dataContext == null)
            {
                _dataContext = new PlantDataContext();
            }

            return _dataContext;
        }
    }
}
