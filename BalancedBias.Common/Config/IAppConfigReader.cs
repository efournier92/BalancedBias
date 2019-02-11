namespace BalancedBias.Common.Config
{
    /// <summary>
    /// Interface implementation of AppConfigReader
    /// </summary>
    public interface IAppConfigReader
    {
        /// <summary>
        /// Get specific app config variable based on key name
        /// </summary>
        /// <param name="appConfigKey"></param>
        /// <returns>App config value as string</returns>
        string AppConfigToString(string appConfigKey);
    }
}
