using StructureMap;

namespace BalancedBias.Common.Infrastructure
{
    /// <summary>
    /// Resolver to support dependency injection
    /// </summary>
    public static class DependencyResolverGateway
    {
        /// <summary>
        /// Dependency injection container as IContainer
        /// </summary>
        private static readonly IContainer Container;

        /// <summary>
        /// Instantiates concrete container for dependency injection
        /// </summary>
        static DependencyResolverGateway()
        {
            Container = new Container(new StructureMapRegistryInitializer());
        }

        /// <summary>
        /// Returns new dependency resolver container
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>New instance of dependency resolver container</returns>
        public static T Resolve<T>()
        {
            return Container.GetInstance<T>();
        }
    }
}
