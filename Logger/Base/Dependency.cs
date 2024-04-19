namespace Logger.Base
{
    public class Dependency : Timer
    {
        public string Operation { get; }
        public bool IsSuccessful { get; set; }

        public Dependency(string name, string operation, Property property) : base(name, property)
        {
            Operation = operation;
            StartTimer();
        }

        public void Complete(bool isSuccessful)
        {
            IsSuccessful = isSuccessful;
        }
    }
}
