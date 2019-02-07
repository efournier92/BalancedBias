using System.Configuration;


namespace BalancedBias.Common.Config
{
    public class AppConfigReader : IAppConfigReader
    {
        public string AppConfigToString(string appConfigKey)
        {
            var appSettingValue = ConfigurationManager.AppSettings[appConfigKey];
            return appSettingValue;
        }
    }
}
