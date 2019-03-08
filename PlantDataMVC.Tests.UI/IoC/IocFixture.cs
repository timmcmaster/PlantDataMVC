using Autofac;

namespace PlantDataMVC.UI.Tests.IoC
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