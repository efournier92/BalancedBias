using System.Configuration;

namespace BalancedBias.Common.Config
{
    public class RssServiceSection : ConfigurationSection
    {
        [ConfigurationProperty("channels")]
        public ChannelElementCollection Channels
        {
            get { return (ChannelElementCollection)this["channels"]; }
            set { this["channels"] = value; }
        }
    }
}
