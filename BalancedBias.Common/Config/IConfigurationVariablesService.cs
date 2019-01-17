using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedBias.Common.Config
{
    public interface IConfigurationVariablesService
    {
        void UpsertConfigVariableByVariableCode(string code, string value);
        string GetConfigVariableValueByVariableCode(string code);
    }
}
