/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML.Voice 
{

    /// <summary>
    /// Echo TwiML Verb
    /// </summary>
    public class Echo : TwiML 
    {
        /// <summary>
        /// Create a new Echo
        /// </summary>
        public Echo() : base("Echo")
        {
        }

        /// <summary>
        /// Return the body of the TwiML tag
        /// </summary>
        protected override string GetElementBody()
        {
            return null;
        }

        /// <summary>
        /// Return the attributes of the TwiML tag
        /// </summary>
        protected override List<XAttribute> GetElementAttributes()
        {
            var attributes = new List<XAttribute>();
            return attributes;
        }
    }

}