namespace YamlSettingsSample.Settings
{
    /// <summary>
    /// This represents the model entity for connection string.
    /// </summary>
    public class ConnectionStringSettings
    {
        /// <summary>
        /// Gets or sets the name of the connection string.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the connection string value.
        /// </summary>
        public string ConnectionString { get; set; }
    }
}