namespace YamlSettingsSample.Settings
{
    /// <summary>
    /// This represents the model entity for Azure Active Directory settings.
    /// </summary>
    public class AzureAdSettings
    {
        /// <summary>
        /// Gets or sets the login URL for Azure Active Directory.
        /// </summary>
        public virtual string AadInstance { get; set; }

        /// <summary>
        /// Gets or sets the domain name for Azure Active Directory.
        /// </summary>
        public virtual string Domain { get; set; }

        /// <summary>
        /// Gets or sets the tenant Id of the registered application on Azure Active Directory.
        /// </summary>
        public virtual string TenantId { get; set; }

        /// <summary>
        /// Gets or sets the client Id of the registered application on Azure Active Directory.
        /// </summary>
        public virtual string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret key of the registered application on Azure Active Directory.
        /// </summary>
        public virtual string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the name of the callback path of the registered application on Azure Active Directory.
        /// </summary>
        public virtual string CallbackPath { get; set; }
    }
}