using System;
using System.Configuration;

namespace BalancedBias.Common.Config
{
    /// <summary>
    /// Generic collection represting a list of ConfigurationElement derived classes
    /// </summary>
    /// <typeparam name="TElement"></typeparam>
    public class GenericConfigurationElementCollection<TElement> : ConfigurationElementCollection
        where TElement : ConfigurationElement, IKeyContainer, new()
    {
        /// <summary>
        /// ConfigurationElement
        /// </summary>
        /// <returns></returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new TElement();
        }

        /// <summary>
        /// GetElementKey
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TElement)element).Key;
        }

        /// <summary>
        /// Retrieves the configuration element at the specified index
        /// </summary>
        /// <param name="index">Index of the configuration element to retrieve</param>
        /// <returns></returns>
        public TElement this[int index]
        {
            get { return BaseGet(index) as TElement; }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }

        }

        /// <summary>
        /// Searches the collection for element by key
        /// </summary>
        /// <param name="key">The value of key attribute to match</param>
        /// <returns>Element with given key value if found, else null</returns>
        public TElement FindElementByKey(string key)
        {
            if (String.IsNullOrEmpty(key)) throw new ArgumentNullException("key");

            foreach (var element in this)
            {
                var configElement = element as TElement;
                if (configElement == null || String.Compare(configElement.Key, key, true) != 0) continue;

                return configElement;
            }
            return null;
        }
    }
}