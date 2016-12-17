using BeeCard.Application.Interfaces;
using BeeCard.Application.Services;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace BeeCard.Utils.DependencyInjection.DependencyResolution
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            For<ITestAppService>().Use<TestAppService>();
        }
    }
}
