namespace PipServices.Commons.Config
{
    /// <summary>
    /// File Config Reader
    /// </summary>
    /// <seealso cref="PipServices.Commons.Config.ConfigReader" />
    public abstract class FileConfigReader : ConfigReader
    {
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileConfigReader"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        public FileConfigReader(string path = null)
        {
            Path = path;
        }

        /// <summary>
        /// Sets the components configuration.
        /// </summary>
        /// <param name="config">Configuration parameters.</param>
        public override void Configure(ConfigParams config)
        {
            base.Configure(config);

            Path = config.GetAsString("path");
        }
    }
}
