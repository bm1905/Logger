namespace Logger.Base
{
    public abstract class OperationBase
    {
        public Property Property { get; }

        public string Name { get; }

        protected OperationBase(string? name, Property? property)
        {
            Name = name ?? string.Empty;
            Property = property ?? new Property();
        }
    }
}
