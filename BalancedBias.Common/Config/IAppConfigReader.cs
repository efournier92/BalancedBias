using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedBias.Common.Config
{
    public interface IAppConfigReader
    {
        string AppConfigToString(string appConfigKey);

        //int AppConfigToInt32(string appConfigKey, int defaultValue = 0);

        //bool IsSwitchedOn(string appConfigKey);

        //string GetConnectionString(string connectionStringName);
    }
}
