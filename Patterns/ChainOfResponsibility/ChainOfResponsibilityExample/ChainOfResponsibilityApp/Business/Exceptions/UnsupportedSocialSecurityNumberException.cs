using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityApp.Business.Exceptions
{
    public class UnsupportedSocialSecurityNumberException : Exception
    {
        public UnsupportedSocialSecurityNumberException()
        {
        }

        public UnsupportedSocialSecurityNumberException(string message) : base(message)
        {
        }

        public UnsupportedSocialSecurityNumberException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnsupportedSocialSecurityNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
