using AutoMapper;
using PlantDataMVC.DTO.Mappers;

namespace PlantDataMVC.WCFService.Mappers
{
    public static class AutoMapperBootstrapper
    {
        private static bool _configured;

        public static void Initialize()
        {
            if (!_configured)
            {
                _configured = true;

                Mapper.Initialize(x => { AutoMapperCoreConfiguration.ConfigAction.Invoke(x); });
            }
        }
    }
}