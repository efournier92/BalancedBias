using System.Configuration;

namespace BalancedBias.Common.Config
{
    /// <inheritdoc />
    /// <summary>
    /// Config reader for ChannelElement section
    /// </summary>
    public class ChannelElement : ConfigurationSection
    {
        /// <summary>
        /// Name config key for ChannelElement
        /// </summary>
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        /// <summary>
        /// Url config value for ChannelElement
        /// </summary>
        [ConfigurationProperty("url")]
        public string Url
        {
            get { return (string)this["url"]; }
            set { this["url"] = value; }
        }

        /// <summary>
        /// Icon config value for ChannelElement
        /// </summary>
        [ConfigurationProperty("icon")]
        public string Icon
        {
            get { return (string)this["icon"]; }
            set { this["icon"] = value; }
        }

        /// <summary>
        /// Template config value for ChannelElement
        /// </summary>
        [ConfigurationProperty("template")]
        public string Template
        {
            get { return (string)this["template"]; }
            set { this["template"] = value; }
        }
    }
}
