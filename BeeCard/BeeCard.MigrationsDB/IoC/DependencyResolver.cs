using BeeCard.Utils.DependencyInjection.DependencyResolution;
using StructureMap;

namespace BeeCard.MigrationsDB.IoC
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
