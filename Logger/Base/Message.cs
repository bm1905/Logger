namespace Logger.Base
{
    public class Message : OperationBase
    {
        public string? Text { get; }

        public Message(string text, Property? property = null) : base(null, property)
        {
            Text = text;
        }

        public Message(string text, string name, Property? property = null) : base(name, property)
        {
            Text = text;
        }

        public static implicit operator Message(string message)
        {
            return new Message(message);
        }
    }
}
