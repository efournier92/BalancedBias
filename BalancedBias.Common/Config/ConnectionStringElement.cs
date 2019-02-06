using System.Configuration;

namespace BalancedBias.Common.Config
{
    public class ConnectionStringElement : ConfigurationSection, IKeyContainer
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Key
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("connectionString")]
        public string ConnectionString
        {
            get { return (string)this["connectionString"]; }
            set { this["connectionString"] = value; }
        }
    }
}