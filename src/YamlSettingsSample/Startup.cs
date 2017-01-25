using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using YamlSettingsSample.Extensions;
using YamlSettingsSample.Settings;

namespace YamlSettingsSample
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(env.ContentRootPath);

            // Adds XML settings
            //builder.AddXmlFile("appsettings.xml", optional: true);

            // Adds JSON settings
            builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            builder.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            // Adds INIT settings
            //builder.AddIniFile("appsettings.ini", optional: true);

            // Adds settings from Azure Key Vault
            //builder.AddAzureKeyVault("https://azure-key-vault-uri", "clientId", "clientSecret");

            // Adds settings manually
            //builder.AddInMemoryCollection(new[]
            //                              {
            //                                  new KeyValuePair<string, string>("authentication:azureAd:clientId",
            //                                                                   "FROM memory collection"),
            //                              });

            // Adds command line arguments
            //builder.AddCommandLine(args);

            // Adds YAML settings
            builder.AddYamlFile("appsettings.yml", optional: true);

            // Adds secret settings (in JSON format)
            if (env.IsDevelopment())
            {
                //builder.AddUserSecrets();
            }

            // Adds environment variables
            builder.AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            var aad = this.Configuration.Get<AzureAdSettings>("authentication:azureAd");

            services.AddSingleton<AzureAdSettings>(aad);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
