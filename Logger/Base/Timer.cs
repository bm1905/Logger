using System.Diagnostics;

namespace Logger.Base
{
    public abstract class Timer : OperationBase
    {
        private Stopwatch? _stopWatch;

        public long? Ticks => _stopWatch?.ElapsedTicks;
        public long? MilliSeconds => _stopWatch?.ElapsedMilliseconds;

        protected Timer(string name, Property property) : base(name, property)
        {

        }

        protected void StartTimer()
        {
            _stopWatch = new Stopwatch();
            _stopWatch.Start();
        }

        public void Complete()
        {
            _stopWatch?.Stop();
        }
    }
}
