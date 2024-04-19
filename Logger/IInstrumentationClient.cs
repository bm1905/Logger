using System.Threading.Tasks;
using Logger.Base;

namespace Logger
{
    public interface IInstrumentationClient
    {
        Task Information(Message message);
        Task Warning(Message message);
        Task Error(ExceptionMessage message);
        Task Dependency(Dependency dependency);
        DependencyOperation Start(string name, string operation, Property property);
    }
}
