using System;
using System.Runtime.Serialization;

namespace HangmanGameLibrary
{
    [Serializable]
    public class InvalidGuessException : Exception
    {
        public InvalidGuessException()
        {
        }

        public InvalidGuessException(string message) : base(message)
        {
        }

        public InvalidGuessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidGuessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}