using PlantDataMVC.Domain.Mappers;

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
                
                AutoMapperWebConfiguration.Configure();

                AutoMapperCoreConfiguration.Configure();
            }
        }
    }
}