/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Preview.DeployedDevices.Fleet 
{

    /// <summary>
    /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
    /// currently do not have developer preview access, please contact help@twilio.com.
    /// 
    /// Fetch information about a specific Certificate credential in the Fleet.
    /// </summary>
    public class FetchCertificateOptions : IOptions<CertificateResource> 
    {
        /// <summary>
        /// The fleet_sid
        /// </summary>
        public string PathFleetSid { get; }
        /// <summary>
        /// A string that uniquely identifies the Certificate.
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchCertificateOptions
        /// </summary>
        ///
        /// <param name="pathFleetSid"> The fleet_sid </param>
        /// <param name="pathSid"> A string that uniquely identifies the Certificate. </param>
        public FetchCertificateOptions(string pathFleetSid, string pathSid)
        {
            PathFleetSid = pathFleetSid;
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
    /// currently do not have developer preview access, please contact help@twilio.com.
    /// 
    /// Unregister a specific Certificate credential from the Fleet, effectively disallowing any inbound client connections
    /// that are presenting it.
    /// </summary>
    public class DeleteCertificateOptions : IOptions<CertificateResource> 
    {
        /// <summary>
        /// The fleet_sid
        /// </summary>
        public string PathFleetSid { get; }
        /// <summary>
        /// A string that uniquely identifies the Certificate.
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new DeleteCertificateOptions
        /// </summary>
        ///
        /// <param name="pathFleetSid"> The fleet_sid </param>
        /// <param name="pathSid"> A string that uniquely identifies the Certificate. </param>
        public DeleteCertificateOptions(string pathFleetSid, string pathSid)
        {
            PathFleetSid = pathFleetSid;
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
    /// currently do not have developer preview access, please contact help@twilio.com.
    /// 
    /// Enroll a new Certificate credential to the Fleet, optionally giving it a friendly name and assigning to a Device.
    /// </summary>
    public class CreateCertificateOptions : IOptions<CertificateResource> 
    {
        /// <summary>
        /// The fleet_sid
        /// </summary>
        public string PathFleetSid { get; }
        /// <summary>
        /// The public certificate data.
        /// </summary>
        public string CertificateData { get; }
        /// <summary>
        /// The human readable description for this Certificate.
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The unique identifier of a Device to be authenticated.
        /// </summary>
        public string DeviceSid { get; set; }

        /// <summary>
        /// Construct a new CreateCertificateOptions
        /// </summary>
        ///
        /// <param name="pathFleetSid"> The fleet_sid </param>
        /// <param name="certificateData"> The public certificate data. </param>
        public CreateCertificateOptions(string pathFleetSid, string certificateData)
        {
            PathFleetSid = pathFleetSid;
            CertificateData = certificateData;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (CertificateData != null)
            {
                p.Add(new KeyValuePair<string, string>("CertificateData", CertificateData));
            }

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }

            if (DeviceSid != null)
            {
                p.Add(new KeyValuePair<string, string>("DeviceSid", DeviceSid.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
    /// currently do not have developer preview access, please contact help@twilio.com.
    /// 
    /// Retrieve a list of all Certificate credentials belonging to the Fleet.
    /// </summary>
    public class ReadCertificateOptions : ReadOptions<CertificateResource> 
    {
        /// <summary>
        /// The fleet_sid
        /// </summary>
        public string PathFleetSid { get; }
        /// <summary>
        /// Find all Certificates authenticating specified Device.
        /// </summary>
        public string DeviceSid { get; set; }

        /// <summary>
        /// Construct a new ReadCertificateOptions
        /// </summary>
        ///
        /// <param name="pathFleetSid"> The fleet_sid </param>
        public ReadCertificateOptions(string pathFleetSid)
        {
            PathFleetSid = pathFleetSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (DeviceSid != null)
            {
                p.Add(new KeyValuePair<string, string>("DeviceSid", DeviceSid.ToString()));
            }

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
    /// currently do not have developer preview access, please contact help@twilio.com.
    /// 
    /// Update the given properties of a specific Certificate credential in the Fleet, giving it a friendly name or
    /// assigning to a Device.
    /// </summary>
    public class UpdateCertificateOptions : IOptions<CertificateResource> 
    {
        /// <summary>
        /// The fleet_sid
        /// </summary>
        public string PathFleetSid { get; }
        /// <summary>
        /// A string that uniquely identifies the Certificate.
        /// </summary>
        public string PathSid { get; }
        /// <summary>
        /// The human readable description for this Certificate.
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The unique identifier of a Device to be authenticated.
        /// </summary>
        public string DeviceSid { get; set; }

        /// <summary>
        /// Construct a new UpdateCertificateOptions
        /// </summary>
        ///
        /// <param name="pathFleetSid"> The fleet_sid </param>
        /// <param name="pathSid"> A string that uniquely identifies the Certificate. </param>
        public UpdateCertificateOptions(string pathFleetSid, string pathSid)
        {
            PathFleetSid = pathFleetSid;
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }

            if (DeviceSid != null)
            {
                p.Add(new KeyValuePair<string, string>("DeviceSid", DeviceSid.ToString()));
            }

            return p;
        }
    }

}