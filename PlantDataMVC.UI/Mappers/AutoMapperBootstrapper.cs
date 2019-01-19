using AutoMapper;
using PlantDataMVC.DTO.Mappers;

namespace PlantDataMVC.UI.Mappers
{
    public static class AutoMapperBootstrapper
    {
        private static bool _configured = false;

        public static void Initialize()
        {
            if (!_configured)
            {
                _configured = true;

                //AutoMapperWebConfiguration.Configure();
                //AutoMapperCoreConfiguration.Configure();

                Mapper.Initialize(x =>
                {
                    AutoMapperWebConfiguration.ConfigAction.Invoke(x);
                    AutoMapperCoreConfiguration.ConfigAction.Invoke(x);
                });
            }
        }
    }
}