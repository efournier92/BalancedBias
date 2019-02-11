using System.Configuration;

namespace BalancedBias.Common.Config
{
    /// <summary>
    /// Returns appSettingValue based on app configuration section
    /// </summary>
    public class AppConfigReader : IAppConfigReader
    {
        public string AppConfigToString(string appConfigKey)
        {
            var appSettingValue = ConfigurationManager.AppSettings[appConfigKey];
            return appSettingValue;
        }
    }
}
