using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ValidSAT.Classes 
{
    [Serializable]
    class ValidationException : Exception
    {
        // Constructors
        public ValidationException(string message) 
        : base(message) 
        { }

        // Ensure Exception is Serializable
        protected ValidationException(SerializationInfo info, StreamingContext ctxt) 
        : base(info, ctxt)
        { }
    }
}
