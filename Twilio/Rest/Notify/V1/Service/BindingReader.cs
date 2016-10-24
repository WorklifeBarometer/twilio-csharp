using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Notify.V1.Service {

    public class BindingReader : Reader<BindingResource> {
        public string serviceSid { get; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public List<string> identity { get; set; }
        public List<string> tag { get; set; }
    
        /// <summary>
        /// Construct a new BindingReader
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        public BindingReader(string serviceSid) {
            this.serviceSid = serviceSid;
        }
    
        /// <summary>
        /// The start_date
        /// </summary>
        ///
        /// <param name="startDate"> The start_date </param>
        /// <returns> this </returns> 
        public BindingReader ByStartDate(DateTime? startDate) {
            this.startDate = startDate;
            return this;
        }
    
        /// <summary>
        /// The end_date
        /// </summary>
        ///
        /// <param name="endDate"> The end_date </param>
        /// <returns> this </returns> 
        public BindingReader ByEndDate(DateTime? endDate) {
            this.endDate = endDate;
            return this;
        }
    
        /// <summary>
        /// The identity
        /// </summary>
        ///
        /// <param name="identity"> The identity </param>
        /// <returns> this </returns> 
        public BindingReader ByIdentity(List<string> identity) {
            this.identity = identity;
            return this;
        }
    
        /// <summary>
        /// The identity
        /// </summary>
        ///
        /// <param name="identity"> The identity </param>
        /// <returns> this </returns> 
        public BindingReader ByIdentity(string identity) {
            return ByIdentity(Promoter.ListOfOne(identity));
        }
    
        /// <summary>
        /// The tag
        /// </summary>
        ///
        /// <param name="tag"> The tag </param>
        /// <returns> this </returns> 
        public BindingReader ByTag(List<string> tag) {
            this.tag = tag;
            return this;
        }
    
        /// <summary>
        /// The tag
        /// </summary>
        ///
        /// <param name="tag"> The tag </param>
        /// <returns> this </returns> 
        public BindingReader ByTag(string tag) {
            return ByTag(Promoter.ListOfOne(tag));
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> BindingResource ResourceSet </returns> 
        public override Task<ResourceSet<BindingResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.NOTIFY,
                "/v1/Services/" + this.serviceSid + "/Bindings"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<BindingResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> BindingResource ResourceSet </returns> 
        public override ResourceSet<BindingResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.NOTIFY,
                "/v1/Services/" + this.serviceSid + "/Bindings"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<BindingResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="nextPageUri"> URI from which to retrieve the next page </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<BindingResource> NextPage(Page<BindingResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.NOTIFY
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of BindingResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<BindingResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("BindingResource read failed: Unable to connect to server");
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
            
            return Page<BindingResource>.FromJson("bindings", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request) {
            if (startDate != null) {
                request.AddQueryParam("StartDate", startDate.ToString());
            }
            
            if (endDate != null) {
                request.AddQueryParam("EndDate", endDate.ToString());
            }
            
            if (identity != null) {
                request.AddQueryParam("Identity", identity.ToString());
            }
            
            if (tag != null) {
                request.AddQueryParam("Tag", tag.ToString());
            }
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}