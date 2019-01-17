using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalancedBias.Common.Config;
using BalancedBias.Common.Infrastructure;
using StructureMap;
using StructureMap.Configuration.DSL;

//using IDependencyResolver = BalancedBias.Common.Infrastructure.IMapper<Pch.Spectrum.DTO.SpectrumRegistrationRequestDto, Pch.RF.API.DTOs.CheckPasswordRequest>;

namespace BalancedBias.Web
{
    public class StructureMapRegistryInitializer : Registry
    {
        public StructureMapRegistryInitializer()
        {
            var databaseConnectionString = "testconnectionstring";

            For<IAppConfigReader>().Use<AppConfigReader>().Ctor<string>("connectionString").Is(databaseConnectionString);
            //For<IAppConfigReader>().Use<AppConfigReader>();

            //this.For<IAppConfigReader>().Use<AppConfigReader>().Ctor<string>("connectionString").Is(databaseConnectionString);
            //this.Policies.SetAllProperties(y => y.WithAnyTypeFromNamespaceContainingType<EmailService>());
        }

    }
}
