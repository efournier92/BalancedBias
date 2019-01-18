using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedBias.Common.Config.Sections
{
    public class RssServiceSection : ConfigurationSection
    {
        /// <summary>
        /// Gets the providers.
        /// </summary>
        /// <value>The providers.</value>
        [ConfigurationProperty("feeds")]
        public ProviderSettingsCollection Feeds
        {
            get
            {
                return (ProviderSettingsCollection)base["feeds"];
            }
        }
    }
}
