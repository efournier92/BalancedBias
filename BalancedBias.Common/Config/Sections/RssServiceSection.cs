using System.Configuration;

namespace BalancedBias.Common.Config.Sections
{
    public class FeedElement : ConfigurationSection
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("url")]
        public string Url
        {
            get { return (string)this["url"]; }
            set { this["url"] = value; }
        }

        [ConfigurationProperty("icon")]
        public string Icon
        {
            get { return (string)this["icon"]; }
            set { this["icon"] = value; }
        }
    }

    [ConfigurationCollection(typeof(FeedElement))]
    public class FeedElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new FeedElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FeedElement)element).Name;
        }
    }

    public class RssServiceSection : ConfigurationSection
    {
        [ConfigurationProperty("feeds")]
        public FeedElementCollection Feeds
        {
            get { return (FeedElementCollection)this["feeds"]; }
            set { this["feeds"] = value; }
        }
    }
}
