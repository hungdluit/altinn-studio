using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Altinn.App.Services.Clients;
using Altinn.App.Services.Configuration;
using Altinn.App.Services.Constants;
using Altinn.App.Services.Interface;
using Altinn.Platform.Storage.Interface.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Altinn.App.Services.Implementation
{
    /// <summary>
    /// service implementation for application in application container mode
    /// </summary>
    public class ApplicationAppSI : IApplication
    {
        private readonly PlatformSettings _platformSettings;
        private readonly ILogger _logger;
        private readonly HttpClient _client;

        private const string SubscriptionKeyHeaderName = "Ocp-Apim-Subscription-Key";

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationAppSI"/> class.
        /// </summary>
        /// <param name="logger">the logger</param>
        /// <param name="httpClientAccessor">The Http client accessor </param>
        public ApplicationAppSI(
           IOptions<PlatformSettings> platformSettings,
            ILogger<ApplicationAppSI> logger,
           HttpClient httpClient)
        {
            _platformSettings = platformSettings.Value;
            _logger = logger;
            httpClient.BaseAddress = new Uri(_platformSettings.ApiStorageEndpoint);
            httpClient.DefaultRequestHeaders.Add(General.SubscriptionKeyHeaderName, _platformSettings.SubscriptionKey);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            _client = httpClient;
        }

        /// <inheritdoc />
        public async Task<Application> GetApplication(string org, string app)
        {
            string appId = $"{org}/{app}";

            Application application = null;
            string getApplicationMetadataUrl = $"applications/{appId}";

            HttpResponseMessage response = await _client.GetAsync(getApplicationMetadataUrl);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string applicationData = await response.Content.ReadAsStringAsync();
                application = JsonConvert.DeserializeObject<Application>(applicationData);
            }
            else
            {
                _logger.LogError($"Unable to fetch application with application id {appId}");
            }

            return application;
        }
    }
}
