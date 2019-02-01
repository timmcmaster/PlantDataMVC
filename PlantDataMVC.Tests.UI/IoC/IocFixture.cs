using Autofac;
using PlantDataMVC.UI;

namespace PlantDataMVC.Tests.UI.IoC
{
    public class IocFixture
    {
        public IocFixture()
        {
            Configure();
        }

        public IContainer Container { get; set; }

        public void Configure()
        {
            Container = AutofacConfig.ConfigureContainer();
        }
    }
}