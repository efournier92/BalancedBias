using System.Configuration;

namespace BalancedBias.Common.Config
{
    /// <summary>
    /// Service section for RssChannels configuration
    /// </summary>
    public class RssChannelsServiceSection : ConfigurationSection
    {
        /// <summary>
        /// Gets and sets Channels configuration property
        /// </summary>
        [ConfigurationProperty("channels")]
        public ChannelElementCollection Channels
        {
            get { return (ChannelElementCollection)this["channels"]; }
            set { this["channels"] = value; }
        }

        /// <summary>
        /// Gets template name from config, based on channel name
        /// </summary>
        /// <param name="channelName"></param>
        /// <returns>Template name as string</returns>
        public static string GetTemplateByChannelName(string channelName)
        {
            var section = (RssChannelsServiceSection)ConfigurationManager.GetSection("rssChannelsService");
            if (section == null) return "Generic";
            var urlConfigurationElement = section.Channels.FindChannelElementByKey(channelName);
            return urlConfigurationElement.Template;
        }
    }
}
