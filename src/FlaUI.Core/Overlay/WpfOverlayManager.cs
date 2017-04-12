using System;
using System.Threading;
using System.Windows.Media;
using System.Windows.Threading;
using FlaUI.Core.Shapes;

namespace FlaUI.Core.Overlay
{
    public class WpfOverlayManager : IOverlayManager
    {
        private readonly Thread _uiThread;
#if NET35
        private readonly ManualResetEvent _startedEvent = new ManualResetEvent(false);
#else
        private readonly ManualResetEventSlim _startedEvent = new ManualResetEventSlim(false);
#endif
        private Dispatcher _dispatcher;
        private OverlayRectangleWindow _currWin;

        public WpfOverlayManager()
        {
            _uiThread = new Thread(() =>
            {
                // Create and install a new dispatcher context
                SynchronizationContext.SetSynchronizationContext(
                    new DispatcherSynchronizationContext(
                        Dispatcher.CurrentDispatcher));

                _dispatcher = Dispatcher.CurrentDispatcher;
                // Signal that it is initialized
                _startedEvent.Set();
                // Start the dispatcher processing
                Dispatcher.Run();
            });

            // Set the apartment state
            _uiThread.SetApartmentState(ApartmentState.STA);
            // Make the thread a background thread
            _uiThread.IsBackground = true;
            // Start the thread
            _uiThread.Start();
#if NET35
            _startedEvent.WaitOne();
#else
            _startedEvent.Wait();
#endif
        }

        public int Size { get; set; }
        public int Margin { get; set; }

        public void Show(Rectangle rectangle, Color color, int durationInMs)
        {
            if (rectangle.IsValid)
            {
                // ReSharper disable once RedundantDelegateCreation Used for older .Net versions
                _dispatcher.Invoke(new Action(() =>
                {
                    _currWin?.Close();
                    var win = new OverlayRectangleWindow(rectangle, color, durationInMs);
                    win.Show();
                    _currWin = win;
                }));
            }
        }

        public void ShowBlocking(Rectangle rectangle, Color color, int durationInMs)
        {
            if (rectangle.IsValid)
            {
                // ReSharper disable once RedundantDelegateCreation Used for older .Net versions
                _dispatcher.Invoke(new Action(() =>
                {
                    _currWin?.Close();
                    var win = new OverlayRectangleWindow(rectangle, color, durationInMs);
                    win.ShowDialog();
                    _currWin = win;
                }));
            }
        }

        public void Dispose()
        {
            _dispatcher.InvokeShutdown();
            _uiThread.Join(1000);
        }
    }
}
