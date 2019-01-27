using StructureMap;
using BalancedBias.Web;

namespace BalancedBias.Common.Infrastructure
{
    public static class DependencyResolverGateway
    {
        private static readonly IContainer Container;

        static DependencyResolverGateway()
        {
            Container = new Container(new StructureMapRegistryInitializer());
        }

        public static T Resolve<T>()
        {
            return Container.GetInstance<T>();
        }
    }
}
