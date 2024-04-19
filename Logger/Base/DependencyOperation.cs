using System;

namespace Logger.Base
{
    public class DependencyOperation : IDisposable
    {
        private Dependency Dependency { get; }
        private readonly ILogger _client;

        public DependencyOperation(ILogger client, string name, string operation, Property property)
        {
            Dependency = new Dependency(name, operation, property);
            _client = client;
        }

        public void Fail()
        {
            Dependency.Complete(false);
        }

        public void Dispose()
        {
            Dependency.Complete();
            _client.Dependency(Dependency);
        }
    }
}
