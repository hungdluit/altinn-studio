using Altinn.Authorization.ABAC.Xacml;
using Altinn.Authorization.ABAC.Xacml.JsonProfile;
using Altinn.Common.PEP.Clients;
using Altinn.Common.PEP.Configuration;
using Altinn.Common.PEP.Helpers;
using Altinn.Common.PEP.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Altinn.Common.PEP.Implementation
{
    /// <summary>
    /// App implementation of the authorization service where the app uses the Altinn platform api.
    /// </summary>
    public class PDPAppSI : IPDP
    {
        private readonly ILogger _logger;
        private readonly PepSettings _pepSettings;
        private readonly AuthorizationApiClient _authorizationApiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationAppSI"/> class
        /// </summary>
        /// <param name="httpClientAccessor">The Http client accessor</param>
        /// <param name="logger">the handler for logger service</param>
        /// /// <param name="pepSettings">The settings for pep</param>
        public PDPAppSI(
                ILogger<PDPAppSI> logger,
                IOptions<PepSettings> pepSettings,
                AuthorizationApiClient authorizationApiClient)
        {
            _logger = logger;
            _pepSettings = pepSettings.Value;
            _authorizationApiClient = authorizationApiClient;
        }

        /// <inheritdoc/>
        public async Task<XacmlJsonResponse> GetDecisionForRequest(XacmlJsonRequestRoot xacmlJsonRequest)
        {
            XacmlJsonResponse xacmlJsonResponse = null;

            if (_pepSettings.DisablePEP)
            {
                return new XacmlJsonResponse
                {
                    Response = new List<XacmlJsonResult>()
                    {
                        new XacmlJsonResult
                        {
                            Decision = XacmlContextDecision.Permit.ToString(),
                        }
                    },
                };
            }

            try
            {
                xacmlJsonResponse = await _authorizationApiClient.AuthorizeRequest(xacmlJsonRequest);
            }
            catch (Exception e)
            {
                _logger.LogError($"Unable to retrieve Xacml Json response. An error occured {e.Message}");
            }

            return xacmlJsonResponse;
        }

        /// <inheritdoc/>
        public async Task<bool> GetDecisionForUnvalidateRequest(XacmlJsonRequestRoot xacmlJsonRequest, ClaimsPrincipal user)
        {
            if (_pepSettings.DisablePEP)
            {
                return true;
            }

            XacmlJsonResponse response = await GetDecisionForRequest(xacmlJsonRequest);

            if (response?.Response == null)
            {
                throw new ArgumentNullException("response");
            }

            _logger.LogInformation($"// Altinn PEP // PDPAppSI // Request sent to platform authorization: {JsonConvert.SerializeObject(xacmlJsonRequest)}");

            return DecisionHelper.ValidatePdpDecision(response.Response, user);
        }
    }
}
