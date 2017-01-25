namespace YamlSettingsSample.Settings
{
    /// <summary>
    /// This represents the model entity for authentication.
    /// </summary>
    public class AuthenticationSettings
    {
        /// <summary>
        /// Gets or sets the <see cref="AzureAdSettings"/> instance.
        /// </summary>
        public virtual AzureAdSettings AzureAd { get; set; }
    }
}