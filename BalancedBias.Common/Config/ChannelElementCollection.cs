using System.Configuration;

namespace BalancedBias.Common.Config
{
    [ConfigurationCollection(typeof(ChannelElement))]
    public class ChannelElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ChannelElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ChannelElement)element).Name;
        }
    }
}