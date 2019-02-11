using BalancedBias.Common.Config;
using StructureMap.Configuration.DSL;

namespace BalancedBias.Common.Infrastructure
{
    /// <inheritdoc />
    /// <summary>
    /// Dependency injection registry mapper
    /// </summary>
    public class StructureMapRegistryInitializer : Registry
    {
        /// <summary>
        /// Initialize dependency injection registry mapper
        /// </summary>
        public StructureMapRegistryInitializer()
        {
            const string databaseConnectionString = "";
            For<IAppConfigReader>().Use<AppConfigReader>().Ctor<string>("connectionString").Is(databaseConnectionString);
        }
    }
}
