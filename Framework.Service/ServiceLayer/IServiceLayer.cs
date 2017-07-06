using Framework.Domain;

namespace Framework.Service.ServiceLayer
{
    public interface IServiceLayer
    {
        /// <summary>
        /// Get the data service for the given type of object.
        /// Again, might be a place for IoC in future?
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IBasicDataService<T> GetDataService<T>() where T : IDomainEntity;
    }
}