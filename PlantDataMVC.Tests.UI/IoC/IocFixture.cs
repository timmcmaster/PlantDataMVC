using Autofac;
using PlantDataMVC.UI;

namespace PlantDataMVC.Tests.UI
{
    public class IocFixture
    {
        public IContainer Container { get; set; }

        public IocFixture()
        {
            this.Configure();
        }

        public void Configure()
        {
            this.Container = AutofacConfig.ConfigureContainer();
        }
    }
}
