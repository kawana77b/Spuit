using System.Windows.Threading;

namespace Spuit.Core
{
    public class UiTimer
    {
        public const int DefaultIntervalMilliseconds = 30;

        public static UiTimer Instance { get; } = new();

        private UiTimer()
        {
        }

        public event EventHandler? Tick;

        private DispatcherTimer? _timer = null;

        public int IntervalMilliseconds { get; set; } = DefaultIntervalMilliseconds;

        public bool IsRunning => _timer is not null;

        public void Start()
        {
            _timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromMilliseconds(IntervalMilliseconds)
            };
            _timer.Tick += Tick;
            _timer.Start();
        }

        public void Stop()
        {
            if (_timer is null) return;

            _timer.Stop();
            _timer = null;
        }
    }
}