using System.Configuration;

namespace BalancedBias.Common.Config
{
    public class ConnectionStringServiceSection : ConfigurationSection
    {
        private const string PromoCodeMessageConfigurationSectionName = "connectionStringSection";

        [ConfigurationProperty("connectionStrings")]
        public GenericConfigurationElementCollection<ConnectionStringElement> ConnectionStrings
        {
            get
            {
                return (GenericConfigurationElementCollection<ConnectionStringElement>)this["connectionStrings"] ??
                       new GenericConfigurationElementCollection<ConnectionStringElement>();
            }
            set { this["connectionStrings"] = value; }
        }

        public string GetConnectionStringByName(string connectionStringName)
        {
            var section = LoadSection(PromoCodeMessageConfigurationSectionName);

            // Get the url based on name
            var connectionStringElement = section.ConnectionStrings.FindElementByKey(connectionStringName);
            return connectionStringElement == null ? null : connectionStringElement.ConnectionString;
        }

        private static ConnectionStringServiceSection LoadSection(string sectionName)
        {
            var section = ConfigurationManager.GetSection(sectionName) as ConnectionStringServiceSection;
            if (section == null)
                throw new ConfigurationErrorsException(string.Format("Failed to load the configuration section: '{0}'",
                    PromoCodeMessageConfigurationSectionName));
            return section;
        }
    }
}
