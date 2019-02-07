namespace BalancedBias.Common.Config
{
    public interface IAppConfigReader
    {
        string AppConfigToString(string appConfigKey);
    }
}
