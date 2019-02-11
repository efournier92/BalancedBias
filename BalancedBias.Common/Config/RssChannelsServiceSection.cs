using System.Configuration;

namespace BalancedBias.Common.Config
{
    public class RssChannelsServiceSection : ConfigurationSection
    {
        [ConfigurationProperty("channels")]
        public ChannelElementCollection Channels
        {
            get { return (ChannelElementCollection)this["channels"]; }
            set { this["channels"] = value; }
        }

        public static string GetTemplateByChannelName(string channelName)
        {
            var section = (RssChannelsServiceSection)ConfigurationManager.GetSection("rssChannelsService");
            if (section == null) return "Generic";
            var urlConfigurationElement = section.Channels.FindChannelElementByKey(channelName);
            return urlConfigurationElement.Template;
        }
    }
}
