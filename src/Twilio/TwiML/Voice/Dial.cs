/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Twilio.TwiML.Voice;
using Twilio.Types;

namespace Twilio.TwiML.Voice 
{

    /// <summary>
    /// Dial TwiML Verb
    /// </summary>
    public class Dial : TwiML 
    {
        public sealed class TrimEnum : StringEnum 
        {
            private TrimEnum(string value) : base(value) {}
            public TrimEnum() {}

            public static readonly TrimEnum TrimSilence = new TrimEnum("trim-silence");
            public static readonly TrimEnum DoNotTrim = new TrimEnum("do-not-trim");
        }

        /// <summary>
        /// Phone number to dial
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Action URL
        /// </summary>
        public Uri Action { get; set; }
        /// <summary>
        /// Action URL method
        /// </summary>
        public Twilio.Http.HttpMethod Method { get; set; }
        /// <summary>
        /// Time to wait for answer
        /// </summary>
        public int? Timeout { get; set; }
        /// <summary>
        /// Hangup call on star press
        /// </summary>
        public bool? HangupOnStar { get; set; }
        /// <summary>
        /// Max time length
        /// </summary>
        public int? TimeLimit { get; set; }
        /// <summary>
        /// Caller ID to display
        /// </summary>
        public string CallerId { get; set; }
        /// <summary>
        /// Record the call
        /// </summary>
        public Dial.TrimEnum Record { get; set; }
        /// <summary>
        /// Trim the recording
        /// </summary>
        public Dial.TrimEnum Trim { get; set; }
        /// <summary>
        /// Recording status callback URL
        /// </summary>
        public Uri RecordingStatusCallback { get; set; }
        /// <summary>
        /// Recording status callback URL method
        /// </summary>
        public Twilio.Http.HttpMethod RecordingStatusCallbackMethod { get; set; }

        /// <summary>
        /// Create a new Dial
        /// </summary>
        /// <param name="number"> Phone number to dial, the body of the TwiML Element. </param>
        /// <param name="action"> Action URL </param>
        /// <param name="method"> Action URL method </param>
        /// <param name="timeout"> Time to wait for answer </param>
        /// <param name="hangupOnStar"> Hangup call on star press </param>
        /// <param name="timeLimit"> Max time length </param>
        /// <param name="callerId"> Caller ID to display </param>
        /// <param name="record"> Record the call </param>
        /// <param name="trim"> Trim the recording </param>
        /// <param name="recordingStatusCallback"> Recording status callback URL </param>
        /// <param name="recordingStatusCallbackMethod"> Recording status callback URL method </param>
        public Dial(string number = null, 
                    Uri action = null, 
                    Twilio.Http.HttpMethod method = null, 
                    int? timeout = null, 
                    bool? hangupOnStar = null, 
                    int? timeLimit = null, 
                    string callerId = null, 
                    Dial.TrimEnum record = null, 
                    Dial.TrimEnum trim = null, 
                    Uri recordingStatusCallback = null, 
                    Twilio.Http.HttpMethod recordingStatusCallbackMethod = null) : base("Dial")
        {
            this.Number = number;
            this.Action = action;
            this.Method = method;
            this.Timeout = timeout;
            this.HangupOnStar = hangupOnStar;
            this.TimeLimit = timeLimit;
            this.CallerId = callerId;
            this.Record = record;
            this.Trim = trim;
            this.RecordingStatusCallback = recordingStatusCallback;
            this.RecordingStatusCallbackMethod = recordingStatusCallbackMethod;
        }

        /// <summary>
        /// Return the body of the TwiML tag
        /// </summary>
        protected override string GetElementBody()
        {
            return this.Number;
        }

        /// <summary>
        /// Return the attributes of the TwiML tag
        /// </summary>
        protected override List<XAttribute> GetElementAttributes()
        {
            var attributes = new List<XAttribute>();
            if (this.Action != null)
            {
                attributes.Add(new XAttribute("action", this.Action.AbsoluteUri));
            }
            if (this.Method != null)
            {
                attributes.Add(new XAttribute("method", this.Method.ToString()));
            }
            if (this.Timeout != null)
            {
                attributes.Add(new XAttribute("timeout", this.Timeout.Value.ToString()));
            }
            if (this.HangupOnStar != null)
            {
                attributes.Add(new XAttribute("hangupOnStar", this.HangupOnStar.Value.ToString()));
            }
            if (this.TimeLimit != null)
            {
                attributes.Add(new XAttribute("timeLimit", this.TimeLimit.Value.ToString()));
            }
            if (this.CallerId != null)
            {
                attributes.Add(new XAttribute("callerId", this.CallerId));
            }
            if (this.Record != null)
            {
                attributes.Add(new XAttribute("record", this.Record.ToString()));
            }
            if (this.Trim != null)
            {
                attributes.Add(new XAttribute("trim", this.Trim.ToString()));
            }
            if (this.RecordingStatusCallback != null)
            {
                attributes.Add(new XAttribute("recordingStatusCallback", this.RecordingStatusCallback.AbsoluteUri));
            }
            if (this.RecordingStatusCallbackMethod != null)
            {
                attributes.Add(new XAttribute("recordingStatusCallbackMethod", this.RecordingStatusCallbackMethod.ToString()));
            }
            return attributes;
        }

        /// <summary>
        /// Create a new <Dial/> element and append it as a child of this element.
        /// </summary>
        /// <param name="name"> Client name, the body of the TwiML Element. </param>
        /// <param name="url"> Client URL </param>
        /// <param name="method"> Client URL Method </param>
        /// <param name="statusCallbackEvent"> Events to trigger status callback </param>
        /// <param name="statusCallback"> Status Callback URL </param>
        /// <param name="statusCallbackMethod"> Status Callback URL Method </param>
        public Dial Client(string name = null, 
                           Uri url = null, 
                           Twilio.Http.HttpMethod method = null, 
                           List<Client.EventEnum> statusCallbackEvent = null, 
                           Uri statusCallback = null, 
                           Twilio.Http.HttpMethod statusCallbackMethod = null)
        {
            var newChild = new Client(name, url, method, statusCallbackEvent, statusCallback, statusCallbackMethod);
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Create a new <Dial/> element and append it as a child of this element.
        /// </summary>
        /// <param name="name"> Conference name, the body of the TwiML Element. </param>
        /// <param name="muted"> Join the conference muted </param>
        /// <param name="beep"> Play beep when joining </param>
        /// <param name="startConferenceOnEnter"> Start the conference on enter </param>
        /// <param name="endConferenceOnExit"> End the conferenceon exit </param>
        /// <param name="waitUrl"> Wait URL </param>
        /// <param name="waitMethod"> Wait URL method </param>
        /// <param name="maxParticipants"> Maximum number of participants </param>
        /// <param name="record"> Record the conference </param>
        /// <param name="region"> Conference region </param>
        /// <param name="whisper"> Call whisper </param>
        /// <param name="trim"> Trim the conference recording </param>
        /// <param name="statusCallbackEvent"> Events to call status callback URL </param>
        /// <param name="statusCallback"> Status callback URL </param>
        /// <param name="statusCallbackMethod"> Status callback URL method </param>
        /// <param name="recordingStatusCallback"> Recording status callback URL </param>
        /// <param name="recordingStatusCallbackMethod"> Recording status callback URL method </param>
        /// <param name="eventCallbackUrl"> Event callback URL </param>
        public Dial Conference(string name = null, 
                               bool? muted = null, 
                               Conference.BeepEnum beep = null, 
                               bool? startConferenceOnEnter = null, 
                               bool? endConferenceOnExit = null, 
                               Uri waitUrl = null, 
                               Twilio.Http.HttpMethod waitMethod = null, 
                               int? maxParticipants = null, 
                               Conference.RecordEnum record = null, 
                               Conference.RegionEnum region = null, 
                               string whisper = null, 
                               Conference.TrimEnum trim = null, 
                               List<Conference.EventEnum> statusCallbackEvent = null, 
                               Uri statusCallback = null, 
                               Twilio.Http.HttpMethod statusCallbackMethod = null, 
                               Uri recordingStatusCallback = null, 
                               Twilio.Http.HttpMethod recordingStatusCallbackMethod = null, 
                               Uri eventCallbackUrl = null)
        {
            var newChild = new Conference(
                name,
                muted,
                beep,
                startConferenceOnEnter,
                endConferenceOnExit,
                waitUrl,
                waitMethod,
                maxParticipants,
                record,
                region,
                whisper,
                trim,
                statusCallbackEvent,
                statusCallback,
                statusCallbackMethod,
                recordingStatusCallback,
                recordingStatusCallbackMethod,
                eventCallbackUrl
            );
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Create a new <Dial/> element and append it as a child of this element.
        /// </summary>
        /// <param name="phoneNumber"> Phone Number to dial, the body of the TwiML Element. </param>
        /// <param name="sendDigits"> DTMF tones to play when the call is answered </param>
        /// <param name="url"> TwiML URL </param>
        /// <param name="method"> TwiML URL method </param>
        /// <param name="statusCallbackEvent"> Events to call status callback </param>
        /// <param name="statusCallback"> Status callback URL </param>
        /// <param name="statusCallbackMethod"> Status callback URL method </param>
        public Dial NumberElement(Types.PhoneNumber phoneNumber = null, 
                                  string sendDigits = null, 
                                  Uri url = null, 
                                  Twilio.Http.HttpMethod method = null, 
                                  List<Number.EventEnum> statusCallbackEvent = null, 
                                  Uri statusCallback = null, 
                                  Twilio.Http.HttpMethod statusCallbackMethod = null)
        {
            var newChild = new Number(
                phoneNumber,
                sendDigits,
                url,
                method,
                statusCallbackEvent,
                statusCallback,
                statusCallbackMethod
            );
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Create a new <Dial/> element and append it as a child of this element.
        /// </summary>
        /// <param name="name"> Queue name, the body of the TwiML Element. </param>
        /// <param name="url"> Action URL </param>
        /// <param name="method"> Action URL method </param>
        /// <param name="reservationSid"> TaskRouter Reservation SID </param>
        /// <param name="postWorkActivitySid"> TaskRouter Activity SID </param>
        public Dial Queue(string name = null, Uri url = null, Twilio.Http.HttpMethod method = null, string reservationSid = null, string postWorkActivitySid = null)
        {
            var newChild = new Queue(name, url, method, reservationSid, postWorkActivitySid);
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Create a new <Dial/> element and append it as a child of this element.
        /// </summary>
        /// <param name="simSid"> SIM SID, the body of the TwiML Element. </param>
        public Dial Sim(string simSid = null)
        {
            var newChild = new Sim(simSid);
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Create a new <Dial/> element and append it as a child of this element.
        /// </summary>
        /// <param name="sipUrl"> SIP URL, the body of the TwiML Element. </param>
        /// <param name="username"> SIP Username </param>
        /// <param name="password"> SIP Password </param>
        /// <param name="url"> Action URL </param>
        /// <param name="method"> Action URL method </param>
        /// <param name="statusCallbackEvent"> Status callback events </param>
        /// <param name="statusCallback"> Status callback URL </param>
        /// <param name="statusCallbackMethod"> Status callback URL method </param>
        public Dial Sip(Uri sipUrl = null, 
                        string username = null, 
                        string password = null, 
                        Uri url = null, 
                        Twilio.Http.HttpMethod method = null, 
                        List<Sip.EventEnum> statusCallbackEvent = null, 
                        Uri statusCallback = null, 
                        Twilio.Http.HttpMethod statusCallbackMethod = null)
        {
            var newChild = new Sip(
                sipUrl,
                username,
                password,
                url,
                method,
                statusCallbackEvent,
                statusCallback,
                statusCallbackMethod
            );
            this.Append(newChild);
            return this;
        }
    }

}