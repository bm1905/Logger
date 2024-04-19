using System;

namespace Logger.Base
{
    [Flags]
    public enum LogLevel
    {
        None,
        Information,
        Error,
        Warning,
        Dependency
    }
}
