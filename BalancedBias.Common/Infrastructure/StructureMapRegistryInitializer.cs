using BalancedBias.Common.Config;
using StructureMap.Configuration.DSL;

namespace BalancedBias.Web
{
    public class StructureMapRegistryInitializer : Registry
    {
        public StructureMapRegistryInitializer()
        {
            var databaseConnectionString = "testconnectionstring";

            For<IAppConfigReader>().Use<AppConfigReader>().Ctor<string>("connectionString").Is(databaseConnectionString);
        }

    }
}
