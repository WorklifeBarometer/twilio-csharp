using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class TaskUpdater : Updater<TaskResource> {
        public string workspaceSid { get; }
        public string sid { get; }
        public string attributes { get; set; }
        public TaskResource.Status assignmentStatus { get; set; }
        public string reason { get; set; }
        public int? priority { get; set; }
        public string taskChannel { get; set; }
    
        /// <summary>
        /// Construct a new TaskUpdater
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        public TaskUpdater(string workspaceSid, string sid) {
            this.workspaceSid = workspaceSid;
            this.sid = sid;
        }
    
        /// <summary>
        /// The attributes
        /// </summary>
        ///
        /// <param name="attributes"> The attributes </param>
        /// <returns> this </returns> 
        public TaskUpdater setAttributes(string attributes) {
            this.attributes = attributes;
            return this;
        }
    
        /// <summary>
        /// The assignment_status
        /// </summary>
        ///
        /// <param name="assignmentStatus"> The assignment_status </param>
        /// <returns> this </returns> 
        public TaskUpdater setAssignmentStatus(TaskResource.Status assignmentStatus) {
            this.assignmentStatus = assignmentStatus;
            return this;
        }
    
        /// <summary>
        /// The reason
        /// </summary>
        ///
        /// <param name="reason"> The reason </param>
        /// <returns> this </returns> 
        public TaskUpdater setReason(string reason) {
            this.reason = reason;
            return this;
        }
    
        /// <summary>
        /// The priority
        /// </summary>
        ///
        /// <param name="priority"> The priority </param>
        /// <returns> this </returns> 
        public TaskUpdater setPriority(int? priority) {
            this.priority = priority;
            return this;
        }
    
        /// <summary>
        /// The task_channel
        /// </summary>
        ///
        /// <param name="taskChannel"> The task_channel </param>
        /// <returns> this </returns> 
        public TaskUpdater setTaskChannel(string taskChannel) {
            this.taskChannel = taskChannel;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated TaskResource </returns> 
        public override async Task<TaskResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks/" + this.sid + ""
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return TaskResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated TaskResource </returns> 
        public override TaskResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks/" + this.sid + ""
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return TaskResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request) {
            if (attributes != null) {
                request.AddPostParam("Attributes", attributes);
            }
            
            if (assignmentStatus != null) {
                request.AddPostParam("AssignmentStatus", assignmentStatus.ToString());
            }
            
            if (reason != null) {
                request.AddPostParam("Reason", reason);
            }
            
            if (priority != null) {
                request.AddPostParam("Priority", priority.ToString());
            }
            
            if (taskChannel != null) {
                request.AddPostParam("TaskChannel", taskChannel);
            }
        }
    }
}