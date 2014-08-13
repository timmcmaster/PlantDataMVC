using PlantDataMvc3.Core.Mappers;
using PlantDataMvc3.DAL.EF.Infrastructure;
//using PlantDataMvc3.DAL.LinqToSql.Infrastructure;

namespace PlantDataMvc3.UI.Mappers
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

                AutoMapperDALConfigurationEF.Configure();

                //AutoMapperDALConfigurationLinqToSql.Configure();
            }
        }
    }
}