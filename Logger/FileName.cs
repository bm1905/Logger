using Logger.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public class FileName
    {
        private readonly IInstrumentationClient _client;

        public FileName(IInstrumentationClient client)
        {
            _client = client;
        }

        public void Test()
        {
            Property property = new Property(new Dictionary<string, string> { { "TestProperty", "TestValue" } });
            using DependencyOperation dependency = _client.Start("", "", property);

        }
    }
}
