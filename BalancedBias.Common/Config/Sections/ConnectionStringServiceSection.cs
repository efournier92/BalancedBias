using System.Configuration;

namespace BalancedBias.Common.Config.Sections
{
    //<add name="FeedsDb" connectionString="Data Source=EFOURNIER-LT\SQLEXPRESS;Initial Catalog=BalancedBias;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;"/>\

    public class ConnectionStringElement : ConfigurationSection
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
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

    [ConfigurationCollection(typeof(ConnectionStringElement))]
    public class ConnectionStringCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConnectionStringElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConnectionStringElement)element).Name;
        }
    }

    public class ConnectionStringServiceSection : ConfigurationSection
    {
        [ConfigurationProperty("connectionStrings")]
        public ConnectionStringCollection ConnectionStrings
        {
            get { return (ConnectionStringCollection)this["connectionStrings"]; }
            set { this["connectionStrings"] = value; }
        }
    }
}
