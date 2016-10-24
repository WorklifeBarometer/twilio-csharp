using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class AuthorizedConnectAppFetcher : Fetcher<AuthorizedConnectAppResource> {
        public string accountSid { get; }
        public string connectAppSid { get; }
    
        /// <summary>
        /// Construct a new AuthorizedConnectAppFetcher.
        /// </summary>
        ///
        /// <param name="connectAppSid"> The connect_app_sid </param>
        public AuthorizedConnectAppFetcher(string connectAppSid) {
            this.connectAppSid = connectAppSid;
        }
    
        /// <summary>
        /// Construct a new AuthorizedConnectAppFetcher
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="connectAppSid"> The connect_app_sid </param>
        public AuthorizedConnectAppFetcher(string accountSid, string connectAppSid) {
            this.accountSid = accountSid;
            this.connectAppSid = connectAppSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched AuthorizedConnectAppResource </returns> 
        public override async Task<AuthorizedConnectAppResource> FetchAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/AuthorizedConnectApps/" + this.connectAppSid + ".json"
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("AuthorizedConnectAppResource fetch failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to fetch record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return AuthorizedConnectAppResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched AuthorizedConnectAppResource </returns> 
        public override AuthorizedConnectAppResource Fetch(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/AuthorizedConnectApps/" + this.connectAppSid + ".json"
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("AuthorizedConnectAppResource fetch failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to fetch record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return AuthorizedConnectAppResource.FromJson(response.Content);
        }
    }
}