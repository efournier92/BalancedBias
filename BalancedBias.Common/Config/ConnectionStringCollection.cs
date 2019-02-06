using System.Configuration;

namespace BalancedBias.Common.Config
{
    [ConfigurationCollection(typeof(ConnectionStringElement))]
    public class ConnectionStringCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConnectionStringElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConnectionStringElement)element).Key;
        }
    }
}