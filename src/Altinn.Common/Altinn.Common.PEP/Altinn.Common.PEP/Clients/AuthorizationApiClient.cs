using Altinn.Authorization.ABAC.Xacml.JsonProfile;
using Altinn.Common.PEP.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Altinn.Common.PEP.Clients
{
    public class AuthorizationApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly PlatformSettings _platformSettings;
        private readonly ILogger _logger;

        public AuthorizationApiClient(HttpClient client, IOptions<PlatformSettings> platformSettings, IOptions<PepSettings> pepSettings, ILogger<AuthorizationApiClient> logger)
        {
            client.BaseAddress = new Uri($"{_platformSettings.GetApiAuthorizationEndpoint}");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient = client;
            _platformSettings = platformSettings.Value;
            _logger = logger;
        }

        public async Task<XacmlJsonResponse> AuthorizeRequest(XacmlJsonRequestRoot xacmlJsonRequest)
        {
            XacmlJsonResponse xacmlJsonResponse = null;
            string apiUrl = $"decision";
            string requestJson = JsonConvert.SerializeObject(xacmlJsonRequest);
            StringContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, httpContent);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                xacmlJsonResponse = JsonConvert.DeserializeObject<XacmlJsonResponse>(responseData);
            }
            else
            {
                _logger.LogInformation($"// PDPAppSI // GetDecisionForRequest // Non-zero status code: {response.StatusCode}");
                _logger.LogInformation($"// PDPAppSI // GetDecisionForRequest // Response: {await response.Content.ReadAsStringAsync()}");
            }

            return xacmlJsonResponse;
        }
    }
}
