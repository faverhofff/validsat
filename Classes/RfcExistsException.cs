using System;
using System.Runtime.Serialization;

namespace ValidSAT.Classes
{
    [Serializable]
    internal class RfcExistsException : Exception
    {
        public RfcExistsException()
        {
        }

        public RfcExistsException(string message) : base(message)
        {
        }

        public RfcExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RfcExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}