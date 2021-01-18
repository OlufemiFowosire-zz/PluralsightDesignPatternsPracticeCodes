using System;
using System.Runtime.Serialization;

namespace HangmanGameLibrary
{
    [Serializable]
    public class DuplicateGuessException : Exception
    {
        public DuplicateGuessException()
        {
        }

        public DuplicateGuessException(string message) : base(message)
        {
        }

        public DuplicateGuessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateGuessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}