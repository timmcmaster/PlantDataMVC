using AutoMapper;
using PlantDataMVC.Domain.Mappers;

namespace PlantDataMVC.WebApi.Mappers
{
    public static class AutoMapperBootstrapper
    {
        private static bool _configured = false;

        public static void Initialize()
        {
            if (!_configured)
            {
                _configured = true;

                Mapper.Initialize(x =>
                {
                    AutoMapperCoreConfiguration.ConfigAction.Invoke(x);
                });
            }
        }
    }
}