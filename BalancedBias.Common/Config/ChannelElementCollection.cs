using System;
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

        public ChannelElement FindChannelElementByKey(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");

            foreach (var element in this)
            {
                var configElement = (ChannelElement)element;
                if (configElement == null || string.Compare(configElement.Name, key, StringComparison.OrdinalIgnoreCase) != 0) continue;

                return configElement;
            }
            return null;
        }
    }
}