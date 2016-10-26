using System;
using System.Threading;
using System.Windows.Media;
using System.Windows.Threading;
using FlaUI.Core.Shapes;

namespace FlaUI.Core.Overlay
{
    public class OverlayManager : IDisposable
    {
        private readonly Thread _uiThread;
        private readonly ManualResetEventSlim _startedEvent = new ManualResetEventSlim(false);
        private Dispatcher _dispatcher;

        public OverlayManager()
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
            _startedEvent.Wait();
        }

        public void Show(Rectangle rectangle, Color color, int durationInMs)
        {
            if (rectangle.IsValid)
            {
                _dispatcher.Invoke(() =>
                {
                    var win = new OverlayRectangleWindow(rectangle, color, durationInMs);
                    win.Show();
                });
            }
        }

        public void ShowBlocking(Rectangle rectangle, Color color, int durationInMs)
        {
            if (rectangle.IsValid)
            {
                _dispatcher.Invoke(() =>
                {
                    var win = new OverlayRectangleWindow(rectangle, color, durationInMs);
                    win.ShowDialog();
                });
            }
        }

        public void Dispose()
        {
            _dispatcher.InvokeShutdown();
            _uiThread.Join(1000);
        }
    }
}
