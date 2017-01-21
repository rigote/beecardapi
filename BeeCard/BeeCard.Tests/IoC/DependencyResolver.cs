using StructureMap;
using BeeCard.Utils.DependencyInjection.DependencyResolution;

namespace BeeCard.Tests.IoC
{
    public static class DependencyResolver
    {
        public static IContainer Container
        {
            get
            {
                return new Container(c => c.AddRegistry<DefaultRegistry>());
            }            
        }
    }
}
