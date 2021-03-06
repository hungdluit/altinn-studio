using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Altinn.Platform.Profile.Configuration;
using Altinn.Platform.Profile.Helpers;
using Altinn.Platform.Profile.Models;
using Altinn.Platform.Profile.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Altinn.Platform.Profile.Services.Implementation
{
    /// <summary>
    /// The organization wrapper
    /// </summary>
    public class UserProfilesWrapper : IUserProfiles
    {
        private readonly ILogger _logger;
        private readonly GeneralSettings _generalSettings;
        private readonly HttpClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfilesWrapper"/> class
        /// </summary>
        /// <param name="httpClient">Httpclient from default httpclient factory</param>
        /// <param name="logger">the logger</param>
        /// <param name="generalSettings">the general settings</param>
        public UserProfilesWrapper(HttpClient httpClient, ILogger<UserProfilesWrapper> logger, IOptions<GeneralSettings> generalSettings)
        {
            _logger = logger;
            _generalSettings = generalSettings.Value;
            _client = httpClient;            
        }

        /// <inheritdoc />
        public async Task<UserProfile> GetUser(int userId)
        {
            UserProfile user = null;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(UserProfile));
            Uri endpointUrl = new Uri($"{_generalSettings.GetApiBaseUrl()}users/{userId}");

            HttpResponseMessage response = await _client.GetAsync(endpointUrl);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();
                user = serializer.ReadObject(stream) as UserProfile;
            }
            else
            {
                _logger.LogError($"Getting user with user id {userId} failed with statuscode {response.StatusCode}");
            }

            return user;
        }

        /// <inheritdoc />
        public async Task<UserProfile> GetUser(string ssn)
        {
            UserProfile user = null;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(UserProfile));

            Uri endpointUrl = new Uri($"{_generalSettings.GetApiBaseUrl()}users");
            StringContent requestBody = new StringContent(JsonSerializer.Serialize(ssn), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync(endpointUrl, requestBody);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Stream stream = await response.Content.ReadAsStreamAsync();
                user = serializer.ReadObject(stream) as UserProfile;
            }
            else
            {
                _logger.LogError($"Getting user by SSN failed with statuscode {response.StatusCode}");
            }

            return user;
        }
    }
}
