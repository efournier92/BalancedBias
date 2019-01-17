using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BalancedBias.Common.Constants;
using System.Configuration;
using System.Web.Configuration;


namespace BalancedBias.Common.Config
{
    public class AppConfigReader : IAppConfigReader
    {
        private readonly string _connectionString;

        public AppConfigReader(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string AppConfigToString(string appConfigKey)
        {
            var appSettingValue = ConfigurationManager.AppSettings[appConfigKey];

            //WebConfigurationManager.AppSettings["newsFeedConfiguration"];
            //Configuration.AppSettings["countoffiles"];
            //ConfigurationManager.AppSettings["countoffiles"];
            return appSettingValue;
        }

        //public int AppConfigToInt32(string appConfigKey, int defaultValue = 0)
        //{
        //    return 1;
        //}

        //public bool IsSwitchedOn(string appConfigKey)
        //{
        //    return true;
        //}

        //public string GetConnectionString(string connectionStringName)
        //{
        //    return "test";
        //}

        //public int AppConfigToInt32(string appConfigKey, int defaultValue = 0)
        //{
        //    int value;
        //    return int.TryParse(InnerAppConfigToString(appConfigKey, false), out value) ? value : defaultValue;
        //}

        //public bool IsSwitchedOn(string appConfigKey)
        //{
        //    var appSetting = InnerAppConfigToString(appConfigKey, false);
        //    return appSetting != null &&
        //           appSetting.ToUpper() == "ON";
        //}

        //public string GetConnectionString(string connectionStringName)
        //{
        //    return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        //}

        //private string InnerAppConfigToString(string appConfigKey, bool forceSsl)
        //{
        //    // Look for the SSL setting if required
        //    string sslSetting = null;
        //    if (WebUtils.IsSslRequest(HttpContext.Current) || forceSsl)
        //    {
        //        var sslKey = "SSL." + appConfigKey;
        //        sslSetting = ConfigurationManager.AppSettings[sslKey];
        //    }

        //    var appSettingValue = sslSetting ?? ConfigurationManager.AppSettings[appConfigKey];

        //    return _appSettingVariableResolver.ResolveVariables(appSettingValue);
        //}

    }
}
