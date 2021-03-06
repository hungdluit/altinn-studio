using System;
using System.IO;
using System.Reflection;

using Altinn.Platform.Register.Configuration;
using Altinn.Platform.Register.Services.Implementation;
using Altinn.Platform.Register.Services.Interfaces;
using Altinn.Platform.Telemetry;
using AltinnCore.Authentication.JwtCookie;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.WindowsServer.TelemetryChannel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using Serilog;
using Serilog.Core;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Altinn.Platform.Register
{
    /// <summary>
    /// Register startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The key valt key for application insights.
        /// </summary>
        internal static readonly string VaultApplicationInsightsKey = "ApplicationInsights--InstrumentationKey";

        /// <summary>
        /// The application insights key.
        /// </summary>
        internal static string ApplicationInsightsKey { get; set; }

        private static readonly Logger _logger = new LoggerConfiguration()
          .WriteTo.Console()
          .CreateLogger();

        private readonly IWebHostEnvironment _env;

        /// <summary>
        ///  Initializes a new instance of the <see cref="Startup"/> class
        /// </summary>
        /// <param name="configuration">The configuration for the register component</param>
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        /// <summary>
        /// Gets register project configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configure register setttings for the service
        /// </summary>
        /// <param name="services">the service configuration</param>
        public void ConfigureServices(IServiceCollection services)
        {
            _logger.Information("Startup // ConfigureServices");

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.AddSingleton(Configuration);
            services.Configure<GeneralSettings>(Configuration.GetSection("GeneralSettings"));

            GeneralSettings generalSettings = Configuration.GetSection("GeneralSettings").Get<GeneralSettings>();
            services.AddAuthentication(JwtCookieDefaults.AuthenticationScheme)
                  .AddJwtCookie(JwtCookieDefaults.AuthenticationScheme, options =>
                  {
                      GeneralSettings generalSettings = Configuration.GetSection("GeneralSettings").Get<GeneralSettings>();
                      options.JwtCookieName = generalSettings.JwtCookieName;
                      options.MetadataAddress = generalSettings.OpenIdWellKnownEndpoint;
                      options.TokenValidationParameters = new TokenValidationParameters
                      {
                          ValidateIssuerSigningKey = true,
                          ValidateIssuer = false,
                          ValidateAudience = false,
                          RequireExpirationTime = true,
                          ValidateLifetime = true
                      };

                      if (_env.IsDevelopment())
                      {
                          options.RequireHttpsMetadata = false;
                      }
                  });

            services.AddHttpClient<IOrganizations, OrganizationsWrapper>();
            services.AddHttpClient<IPersons, PersonsWrapper>();
            services.AddHttpClient<IParties, PartiesWrapper>();

            if (!string.IsNullOrEmpty(ApplicationInsightsKey))
            {
                services.AddSingleton(typeof(ITelemetryChannel), new ServerTelemetryChannel() { StorageFolder = "/tmp/logtelemetry" });
                services.AddApplicationInsightsTelemetry(ApplicationInsightsKey);
                services.AddSingleton<ITelemetryInitializer, CustomTelemetryInitializer>();

                _logger.Information($"Startup // ApplicationInsightsTelemetryKey = {ApplicationInsightsKey}");
            }

            // Add Swagger support (Swashbuckle)
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Altinn Platform Register", Version = "v1" });
                IncludeXmlComments(c);
            });
        }

        private void IncludeXmlComments(SwaggerGenOptions swaggerGenOptions)
        {
            try
            {
                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                swaggerGenOptions.IncludeXmlComments(xmlPath);
            }
            catch (Exception e)
            {
                _logger.Warning("Exception when attempting to include the XML comments file(s): " + e.Message);
            }
        }

        /// <summary>
        /// Default configuration for the register component
        /// </summary>
        /// <param name="app">the application builder</param>
        /// <param name="env">the hosting environment</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            _logger.Information("Startup // Configure");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                _logger.Information("IsDevelopment");
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseSwagger(o => o.RouteTemplate = "register/swagger/{documentName}/swagger.json");

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/register/swagger/v1/swagger.json", "Altinn Platform Register API");
                c.RoutePrefix = "register/swagger";
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
