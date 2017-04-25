using System;
using System.Runtime.Serialization;

namespace ValidSAT.Classes
{
    [Serializable]
    internal class RegexMatchTimeoutException : Exception
    {
        public RegexMatchTimeoutException()
        {
        }

        public RegexMatchTimeoutException(string message) : base(message)
        {
        }

        public RegexMatchTimeoutException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RegexMatchTimeoutException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}