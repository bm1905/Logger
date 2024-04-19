using System;

namespace Logger.Base
{
    public class ExceptionMessage : Message
    {
        public Exception Exception { get; }

        public static implicit operator ExceptionMessage(string message)
        {
            return new ExceptionMessage(message);
        }

        public static implicit operator ExceptionMessage(Exception ex)
        {
            return new ExceptionMessage(ex);
        }

        public ExceptionMessage(string message, Property? property = null) : base(message, string.Empty, property)
        {
            Exception = new Exception(message);
        }

        public ExceptionMessage(Exception ex, Property? property = null) : base(ex.Message, string.Empty, property)
        {
            Exception = ex;
        }

        public ExceptionMessage(Exception ex,string message, Property? property = null) : base(message, string.Empty, property)
        {
            Exception = ex;
        }

        public ExceptionMessage(string name, Exception ex, string message, Property? property = null) : base(message, name, property)
        {
            Exception = ex;
        }
    }
}
