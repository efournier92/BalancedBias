using System;
using System.Configuration;

namespace BalancedBias.Common.Config
{
    /// <summary>
    /// Config element collection for ChannelElementCollection
    /// </summary>
    [ConfigurationCollection(typeof(ChannelElement))]
    public class ChannelElementCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Creates a new ChannelElement
        /// </summary>
        /// <returns>New ChannelElement</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ChannelElement();
        }

        /// <summary>
        /// Gets ChannelElement name from element
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Channel element name</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ChannelElement)element).Name;
        }

        /// <summary>
        /// Get ChannelElement based on inputed key name
        /// </summary>
        /// <param name="key"></param>
        /// <returns>ChannelElement</returns>
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