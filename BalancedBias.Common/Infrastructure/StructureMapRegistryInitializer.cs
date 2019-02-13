using BalancedBias.Common.Config;
using BalancedBias.Common.Connectivity;
using BalancedBias.Common.Rss;
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
            For<IAppConfigReader>().Use<AppConfigReader>();
            For<IChannelsDbService>().Use<ChannelsDbService>();
            For<IRssChannelsService>().Use<RssChannelsService>();
        }
    }
}
