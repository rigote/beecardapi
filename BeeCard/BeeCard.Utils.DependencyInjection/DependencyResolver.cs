using StructureMap;

namespace BeeCard.Utils.DependencyInjection
{
    public static class DependencyResolver
    {
        public static Container Container;

        public static void Resolve()
        {
            Container = new Container(_ => {
                
            });
        }
    }
}
