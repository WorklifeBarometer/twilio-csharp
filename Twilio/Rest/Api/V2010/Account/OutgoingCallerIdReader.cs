using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class OutgoingCallerIdReader : Reader<OutgoingCallerIdResource> {
        public string accountSid { get; }
        public Twilio.Types.PhoneNumber phoneNumber { get; set; }
        public string friendlyName { get; set; }
    
        /// <summary>
        /// Construct a new OutgoingCallerIdReader.
        /// </summary>
        public OutgoingCallerIdReader() {
        }
    
        /// <summary>
        /// Construct a new OutgoingCallerIdReader
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        public OutgoingCallerIdReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /// <summary>
        /// Only show the caller id resource that exactly matches this phone number
        /// </summary>
        ///
        /// <param name="phoneNumber"> Filter by phone number </param>
        /// <returns> this </returns> 
        public OutgoingCallerIdReader ByPhoneNumber(Twilio.Types.PhoneNumber phoneNumber) {
            this.phoneNumber = phoneNumber;
            return this;
        }
    
        /// <summary>
        /// Only show the caller id resource that exactly matches this name
        /// </summary>
        ///
        /// <param name="friendlyName"> Filter by friendly name </param>
        /// <returns> this </returns> 
        public OutgoingCallerIdReader ByFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> OutgoingCallerIdResource ResourceSet </returns> 
        public override Task<ResourceSet<OutgoingCallerIdResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/OutgoingCallerIds.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<OutgoingCallerIdResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> OutgoingCallerIdResource ResourceSet </returns> 
        public override ResourceSet<OutgoingCallerIdResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/OutgoingCallerIds.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<OutgoingCallerIdResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="nextPageUri"> URI from which to retrieve the next page </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<OutgoingCallerIdResource> NextPage(Page<OutgoingCallerIdResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of OutgoingCallerIdResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<OutgoingCallerIdResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("OutgoingCallerIdResource read failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to read records, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return Page<OutgoingCallerIdResource>.FromJson("outgoing_caller_ids", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request) {
            if (phoneNumber != null) {
                request.AddQueryParam("PhoneNumber", phoneNumber.ToString());
            }
            
            if (friendlyName != null) {
                request.AddQueryParam("FriendlyName", friendlyName);
            }
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}