using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedBias.Common.Config.Sections
{
    //public class FeedElement : ConfigurationElement
    public class FeedElement : ConfigurationSection
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        //[RegexStringValidator(@"https?\://\S+")]
        [ConfigurationProperty("url")]
        public string Url
        {
            get { return (string)this["url"]; }
            set { this["url"] = value; }
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

    public class FeedRetrieverSection : ConfigurationSection
    {
        [ConfigurationProperty("feeds")]
        public FeedElementCollection Feeds
        {
            get { return (FeedElementCollection)this["feeds"]; }
            set { this["feeds"] = value; }
        }
    }

    //public class RssServiceSection : ConfigurationSection
    //{
    //    /// <summary>
    //    /// Gets the providers.
    //    /// </summary>
    //    /// <value>The providers.</value>
    //    [ConfigurationProperty("feeds")]
    //    public ProviderSettingsCollection Feeds
    //    {
    //        get
    //        {
    //            return (ProviderSettingsCollection)base["feeds"];
    //        }
    //    }
    //}
}
